using Elsa.Management.Models;
using Elsa.Management.Services;
using Elsa.Scripting.JavaScript.Expressions;
using Elsa.Services;

namespace Elsa.Scripting.JavaScript.Providers;

public class JavaScriptExpressionSyntaxProvider : IExpressionSyntaxProvider
{
    public const string SyntaxName = "JavaScript";
    private readonly IIdentityGenerator _identityGenerator;

    public JavaScriptExpressionSyntaxProvider(IIdentityGenerator identityGenerator)
    {
        _identityGenerator = identityGenerator;
    }

    public ValueTask<IEnumerable<ExpressionSyntaxDescriptor>> GetDescriptorsAsync(CancellationToken cancellationToken = default)
    {
        var javaScript = CreateJavaScriptDescriptor();

        return ValueTask.FromResult<IEnumerable<ExpressionSyntaxDescriptor>>(new[] { javaScript });
    }

    private ExpressionSyntaxDescriptor CreateJavaScriptDescriptor() => new()
    {
        Syntax = SyntaxName,
        Type = typeof(JavaScriptExpression),
        CreateExpression = CreateJavaScriptExpression,
        CreateLocationReference = context =>
        {
            var reference = new JavaScriptExpressionReference(context.GetExpression<JavaScriptExpression>());

            if (string.IsNullOrWhiteSpace(reference.Id))
                reference.Id = GenerateId();

            return reference;
        },
        CreateSerializableObject = context => new
        {
            Type = SyntaxName,
            context.GetExpression<JavaScriptExpression>().Value
        }
    };

    private IExpression CreateJavaScriptExpression(ExpressionConstructorContext context)
    {
        var script = context.Element.TryGetProperty("value", out var p) ? p.ToString() : "";
        return new JavaScriptExpression(script);
    }

    private string GenerateId() => _identityGenerator.GenerateId();
}