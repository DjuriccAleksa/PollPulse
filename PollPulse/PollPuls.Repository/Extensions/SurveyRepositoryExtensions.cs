using PollPulse.Entities.Models;
using System.Reflection;
using System.Linq.Dynamic.Core;
using System.Text;

namespace PollPulse.Repository.Extensions;

public static class SurveyRepositoryExtensions
{
    public static IQueryable<Survey> Filter(this IQueryable<Survey> query, DateTime dateCreatedAfter) => query.Where(s => s.DateCreated > dateCreatedAfter);

    public static IQueryable<Survey> Search(this IQueryable<Survey> query, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrEmpty(searchTerm))
            return query;

        var lowerCaseSearch = searchTerm.Trim().ToLower();

        return query.Where(s => s.Title.ToLower().Contains(lowerCaseSearch));
    }

    public static IQueryable<Survey> Sort(this IQueryable<Survey> query, string orderByQueryString)
    {
        if(string.IsNullOrWhiteSpace(orderByQueryString))
            return query.OrderBy(s => s.Title);

        var orderPrameters = orderByQueryString.Trim().Split(',');
        var propertyInfos = typeof(Survey).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var orderQueryBuilder = new StringBuilder();

        foreach(var param in orderPrameters)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;

            var propertyFromQueryName = param.Split(' ')[0];
            var propertyObject = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

            if (propertyObject is null)
                continue;

            var orderDirection = param.EndsWith(" desc") ? "descending" : "ascending";

            orderQueryBuilder.Append($"{propertyObject.Name.ToString()} {orderDirection}, ");
        }

        var orderQuery = orderQueryBuilder.ToString().TrimEnd(',',' ');
        if (string.IsNullOrWhiteSpace(orderQuery))
            return query.OrderBy(s => s.Title);

        return query.OrderBy(orderQuery);
    }
}
