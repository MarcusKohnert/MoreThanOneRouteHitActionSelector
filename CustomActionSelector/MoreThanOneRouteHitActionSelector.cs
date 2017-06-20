using Microsoft.AspNetCore.Mvc.Internal;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Abstractions;
using System.Linq;

namespace CustomActionSelector
{
    public class MoreThanOneRouteHitActionSelector : ActionSelector
    {
        public MoreThanOneRouteHitActionSelector(
            IActionSelectorDecisionTreeProvider decisionTreeProvider, 
            ActionConstraintCache actionConstraintCache, 
            ILoggerFactory loggerFactory) 
            : base(decisionTreeProvider, actionConstraintCache, loggerFactory)
        {
        }

        protected override IReadOnlyList<ActionDescriptor> SelectBestActions(IReadOnlyList<ActionDescriptor> actions)
        {
            if (actions.HasLessThan(2)) return base.SelectBestActions(actions); // works like base implementation

            foreach (var action in actions)
            {
                if (action.Parameters.Any(p => p.Name == "identifier"))
                {
                    /*** get value of identifier from route (launchSettings this would result in 'someIdentifier') ***/
                    
                    // call logic that decides whether value of identifier matches the controller

                    // if yes
                    return new List<ActionDescriptor>(new[] { action }).AsReadOnly();

                    // else 
                    // keep going
                }
            }

            return base.SelectBestActions(actions); // fail in all other cases with AmbiguousActionException
        }
    }

    public static partial class IEnumerableExtensions
    {
        public static bool HasLessThan<T>(this IReadOnlyCollection<T> source, int lessThan) => source.Count < lessThan;
    }
}