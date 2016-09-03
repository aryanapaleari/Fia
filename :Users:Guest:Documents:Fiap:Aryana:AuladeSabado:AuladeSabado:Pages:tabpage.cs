using System;

using Xamarin.Forms;

namespace AuladeSabado
{
	public class tabpage : TabbedPage
	{
		public tabpage()
		{
			TabbedPage = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


