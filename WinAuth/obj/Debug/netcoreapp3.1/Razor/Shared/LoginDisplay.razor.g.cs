#pragma checksum "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Shared\LoginDisplay.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d5399a1ea512bb21c1c161fff3f066cfca9eab2"
// <auto-generated/>
#pragma warning disable 1591
namespace WinAuth.Shared
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
#line 10 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\_Imports.razor"
using Microsoft.AspNetCore.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Shared\LoginDisplay.razor"
using Core;

#line default
#line hidden
#nullable disable
    public partial class LoginDisplay : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(0);
            __builder.AddAttribute(1, "class", "nav-link");
            __builder.AddAttribute(2, "href", "account");
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(4, "\r\n    ");
                __builder2.AddMarkupContent(5, "<button class=\"btn btn-outline-primary\">Account</button>\r\n");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Settings Settings { get; set; }
    }
}
#pragma warning restore 1591
