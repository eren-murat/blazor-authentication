#pragma checksum "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Pages\SignOut.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b4d44f16c7efc98ef6b5a6fd0bff552178c7405a"
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
#line 10 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\_Imports.razor"
using Microsoft.AspNetCore.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Pages\SignOut.razor"
using Core;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/signedout")]
    public partial class SignOut : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Signed Out</h3>\r\n\r\n");
            __builder.AddMarkupContent(1, "<p>Click to <a href=\"/signin\">sign in</a></p>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Settings Settings { get; set; }
    }
}
#pragma warning restore 1591
