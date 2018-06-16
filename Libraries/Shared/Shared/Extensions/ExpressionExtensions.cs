using System;
using System.Linq.Expressions;

namespace SkillsCrafter.Shared.Extensions
{
	public static class ExpressionExtensions
	{
		#region Methods.Public

		public static String FindPath(this Expression expression)
		{
			LambdaExpression lambda = expression as LambdaExpression;
			//
			MemberExpression member = null;
			if (lambda.Body is UnaryExpression) member = (lambda.Body as UnaryExpression).Operand as MemberExpression;
			else member = lambda.Body as MemberExpression;
			//
			String result = member.ToString();
			return result.Substring(result.IndexOf('.') + 1);
		}

		public static String FindPropertyName(this Expression expression)
		{
			LambdaExpression lambda = expression as LambdaExpression;
			//
			MemberExpression member = null;
			if (lambda.Body is UnaryExpression) member = (lambda.Body as UnaryExpression).Operand as MemberExpression;
			else member = lambda.Body as MemberExpression;
			//
			return member.Member.Name;
		}

		#endregion
	}
}
