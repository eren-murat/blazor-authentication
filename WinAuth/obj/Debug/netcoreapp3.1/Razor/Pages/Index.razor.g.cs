#pragma checksum "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32c1b4465afa1497f1fd35fdb2ba19678cc1ec77"
// <auto-generated/>
#pragma warning disable 1591
namespace WinAuth.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\_Imports.razor"
using WinAuth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\_Imports.razor"
using WinAuth.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Pages\Index.razor"
using Core;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Hello, world!</h1>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Pages\Index.razor"
 if (Settings.isLoggedIn)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(1, "    ");
            __builder.OpenElement(2, "p");
            __builder.AddMarkupContent(3, "\r\n        Welcome to our new app, ");
            __builder.AddContent(4, 
#nullable restore
#line 12 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Pages\Index.razor"
                                 Settings.GetUserName()

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(5, "!\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n");
#nullable restore
#line 14 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Pages\Index.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(7, "    ");
            __builder.AddMarkupContent(8, "<p>\r\n        You are not authenticated.\r\n    </p>\r\n");
#nullable restore
#line 20 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Pages\Index.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Settings Settings { get; set; }
    }
}
#pragma warning restore 1591
