using System.Reflection;

namespace TMom.Infrastructure.Common
{
    public static class GenericTypeExtensions
    {
        public static string GetGenericTypeName(this Type type)
        {
            var typeName = string.Empty;

            if (type.IsGenericType)
            {
                var genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.Name).ToArray());
                typeName = $"{type.Name.Remove(type.Name.IndexOf('`'))}<{genericTypes}>";
            }
            else
            {
                typeName = type.Name;
            }

            return typeName;
        }

        public static string GetGenericTypeName(this object @object)
        {
            return @object.GetType().GetGenericTypeName();
        }

        /// <summary>
        /// 判断是否为可空字符串类型: string?
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static bool IsNullStringType(this PropertyInfo propertyInfo)
        {
            // TODO
            bool isNull = propertyInfo.PropertyType == typeof(string) && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>);
            return isNull;
        }
    }
}