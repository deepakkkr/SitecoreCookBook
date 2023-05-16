using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCookBook.Commands
{
    public class GetChildCount : Command
    {
        public override void Execute(CommandContext context)
        {
            if (context.Items.Length == 1)
            {
                Item currentItem = context.Items[0];
                SheerResponse.Alert(string.Format("Children count: {0}",currentItem.Children.Count));
            }
        }
        public override CommandState QueryState(CommandContext context)
        {
            if (context.Items.Length == 1)
            {
                Item currentItem = context.Items[0];
                if (currentItem.Children.Count == 0)
                    return CommandState.Disabled;
            }
            return base.QueryState(context);
        }
    }
}