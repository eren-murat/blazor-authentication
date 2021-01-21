// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
using System.Security.Principal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Pages\Index.razor"
using Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Pages\Index.razor"
using DataAccess;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 63 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Pages\Index.razor"
 
    bool showModal = false;

    private AuthenticationState authState;
    private WindowsIdentity windowsIdentity;

    private string username { get; set; }
    private string password { get; set; }

    private string errorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (Settings.UseWindowsAuthentication())
        {
            // go directly to home page
            authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            windowsIdentity = (WindowsIdentity)authState.User.Identity;

            Settings.LoginUser(windowsIdentity);
        }

        if (!Settings.UseWindowsAuthentication() && !Settings.IsUserLoggedIn())
        {
            // show login window
            showModal = true;
        }
    }

    private void SignInUser()
    {
        if (SqlDataAccess.VerifySqlConnection(username, password))
        {
            Console.WriteLine("connection open");

            Settings.LoginUser(username, password, DateTime.Now);

            showModal = false;

            StateHasChanged();
        }
        else
        {
            errorMessage = "Wrong username or password";
            StateHasChanged();
        }
    }

    private void ModalCancel()
    {
        showModal = false;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ISqlDataAccess SqlDataAccess { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Settings Settings { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
