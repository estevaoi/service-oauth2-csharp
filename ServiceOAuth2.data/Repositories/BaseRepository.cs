using Dapper;
using MySql.Data.MySqlClient;
using ServiceOAuth2.comum.Extensions;
using ServiceOAuth2.data.Interfaces;
using ServiceOAuth2.data.Models;
using ServiceOAuth2.domain.Entities;
using ServiceOAuth2.domain.Enums;
using ServiceOAuth2.domain.Response;
using System.Data;
using System.Runtime.CompilerServices;

namespace ServiceOAuth2.data.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly string _connectionString = Environment.GetEnvironmentVariable("DatabaseConnectionString");

        public BaseRepository() { }

        #region Métodos privados

        private List<PropertyData> GetPropertiesData<M>(object model)
        {
            List<PropertyData> properties = new List<PropertyData>();

            foreach (var property in typeof(M).GetProperties())
            {
                var propertyName = property.Name;
                var propertyValue = model.GetType().Name == "String" ? "" : property.GetValue(model)?.ToString() ?? "";
                var propertyOperator = propertyValue.Contains("%") ? "LIKE" : "=";
                var propertyAttribute = property.GetCustomAttributesData()?.FirstOrDefault()?.ConstructorArguments[0].Value?.ToString() ?? "";
                var propertyIsQueryWhere = !String.IsNullOrEmpty(propertyAttribute) && !String.IsNullOrEmpty(propertyValue);

                properties.Add(new PropertyData
                {
                    Name = propertyName,
                    Attribute = propertyAttribute,
                    Value = propertyValue,
                    Operator = propertyOperator,
                    IsQueryWhere = propertyIsQueryWhere
                });
            }

            return properties;
        }

        private List<FieldOrderByData> ParseFieldsOrderBy(string columns)
        {
            var fields = new List<FieldOrderByData>();

            foreach (var item in (columns ?? "").ToUpper().Split(","))
            {
                var fieldsSplit = item.Trim().Split(' ');
                var field = fieldsSplit[0];
                var ording = fieldsSplit.Length > 1 && fieldsSplit[1] == "DESC" ? "DESC" : "ASC";

                fields.Add(new FieldOrderByData
                {
                    Field = field,
                    Ording = ording
                });
            }

            return fields;
        }

        private int TotalPagina(decimal total, decimal quantidadePorPagina)
        {
            return (quantidadePorPagina == 0) ? 0 : Convert.ToInt32(Math.Ceiling(total / quantidadePorPagina));
        }

        private PaginationResponse Paginacao(int total, BaseModel model, string modulo)
        {
            return new PaginationResponse
            {
                Id = $"lista{modulo}",
                TotalItems = total,
                TotalPages = TotalPagina(total, model.ItemsPerPage),
                CurrentPage = model.Page,
                ItemsPerPage = model.ItemsPerPage
            };
        }

        private string QueryPagination(BaseModel model)
        {
            return model.Page > 0 ? $" LIMIT {(model.Page - 1) * model.ItemsPerPage}, {model.ItemsPerPage}" : "";
        }

        private string QueryWhere<M, E>(M model)
        {
            var propertiesData = GetPropertiesData<M>(model);
            var orderBy = propertiesData.Find(x => x.Name == "OrderBy").Value;
            var queryWhere = propertiesData.Where(x => x.IsQueryWhere)
                                               .Select(x => $"{x.Attribute} {x.Operator} @{x.Name}")
                                               .ToList();

            return (queryWhere.Count > 0 ? " WHERE " : "") + string.Join(" AND ", queryWhere) + QueryOrderBy<E>(orderBy);
        }

        private string QueryOrderBy<T>(string columns)
        {
            var properties = GetPropertiesData<T>(columns).ToDictionary(x => x.Name.ToUpper());

            var fieldsOrderBy = ParseFieldsOrderBy(columns)
                               .Select(column => (isContains: properties.TryGetValue(column.Field, out var propertyData), propertyData, column))
                               .Where(x => x.isContains)
                               .Select(x => $"{x.propertyData.Attribute} {x.column.Ording}")
                               .ToList();

            return (fieldsOrderBy.Count > 0 ? " ORDER BY " : "") + string.Join(", ", fieldsOrderBy);
        }

        #endregion

        #region Métodos públicos

        public async Task<(List<E> List, PaginationResponse Pagination)> Get<E, M>(string sql, M query, [CallerFilePath] string sourceFilePath = "")
        {
            var modulo = Path.GetFileNameWithoutExtension(sourceFilePath).ParseNameClass(false);

            try
            {
                var baseModel = query.CastX<BaseModel>();

                using var connection = new MySqlConnection(_connectionString);

                var sqlQuery = sql + QueryWhere<M, E>(query);
                var consulta = (await connection.QueryAsync<E>(sqlQuery + QueryPagination(baseModel), query)).ToList();
                var total = baseModel.Page == 0 ? consulta.Count : await connection.QueryFirstAsync<int>($"SELECT COUNT(*) TOTAL FROM ({sqlQuery}) AS TABELA", query);

                return (consulta, Paginacao(total, baseModel, modulo));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Execute<T>(string sql, T dto, ExecuteTypeSqlEnum tipo, [CallerFilePath] string sourceFilePath = "")
        {
            var memberClassName = Path.GetFileNameWithoutExtension(sourceFilePath);

            try
            {
                using var connection = new MySqlConnection(_connectionString);
                return tipo switch
                {
                    ExecuteTypeSqlEnum.INSERT => await connection.ExecuteAsync(sql, dto) > 0,
                    ExecuteTypeSqlEnum.UPDATE => await connection.ExecuteAsync(sql, dto) > 0,
                    ExecuteTypeSqlEnum.DELETE => await connection.ExecuteAsync(sql, dto) > 0,
                    _ => false,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
