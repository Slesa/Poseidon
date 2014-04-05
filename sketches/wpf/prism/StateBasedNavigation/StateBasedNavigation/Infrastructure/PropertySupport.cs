using System;
using System.Linq.Expressions;
using System.Reflection;

namespace StateBasedNavigation.Infrastructure
{
    public static class PropertySupport
    {
         public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
         {
             if (propertyExpression == null)
             {
                 throw new ArgumentNullException("propertyExpression");
             }

             var memberExpression = propertyExpression.Body as MemberExpression;
             if (memberExpression == null)
             {
                 throw new ArgumentException("The expression is not a member access expression", "propertyExpression");
             }

             var property = memberExpression.Member as PropertyInfo;
             if (property == null)
             {
                 throw new ArgumentException("The member access expression does not access a property", "propertyExpression");
             }

             var getMethod = property.GetGetMethod(true);
             if (getMethod.IsStatic)
             {
                 throw new ArgumentException("The referenced property is a static property", "propertyExpression");
             }
             return memberExpression.Member.Name;
         }
    }
}