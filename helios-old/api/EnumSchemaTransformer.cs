using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;


public class EnumSchemaTransformer : IOpenApiSchemaTransformer
{
    public Task TransformAsync(OpenApiSchema schema, OpenApiSchemaTransformerContext context, CancellationToken cancellationToken)
    {
        var type = context.JsonPropertyInfo?.PropertyType;

        // Gère les Nullable<Enum>
        var underlyingType = Nullable.GetUnderlyingType(type ?? typeof(object)) ?? type;

        if (underlyingType == null || !underlyingType.IsEnum)
            return Task.CompletedTask;

        var enumNames = Enum.GetNames(underlyingType);
        schema.Type = "string";
        schema.Enum = enumNames.Select(n => new OpenApiString(n)).Cast<IOpenApiAny>().ToList();

        return Task.CompletedTask;
    }
}

