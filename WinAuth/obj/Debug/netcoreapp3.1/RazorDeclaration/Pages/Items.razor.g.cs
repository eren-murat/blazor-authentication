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
#line 3 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Pages\Items.razor"
using DataAccess;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Pages\Items.razor"
using DataAccess.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Pages\Items.razor"
using WinAuth.Components;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/items")]
    public partial class Items : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 188 "C:\Users\eren.murat\source\repos\blazor-app\WinAuth\Pages\Items.razor"
       
    private IEnumerable<ObjModel> objects;

    private List<ObjModExtended> rows = new List<ObjModExtended>();

    private Details itemDetails = new Details();

    private ObjModExtended newComponent = new ObjModExtended();

    private User user = new User();

    private bool itemCreation = false;

    private List<string> dataTypes = new List<string> { "INT", "VARCHAR(255)", "DATETIME", "other..." };

    private bool editable = false;

    private bool editNow = false;

    private bool reset = false;

    protected override async Task OnInitializedAsync()
    {
        objects = await SqlDataAccess.LoadData();

        int idCount = 0;

        foreach (var item in objects)
        {
            ObjModExtended temp = new ObjModExtended();

            temp.CopyFields(item, SqlDataAccess);

            temp.ProprietatiLabel = await SqlDataAccess.GetLabelPropertyByID(item.Id);
            temp.ProprietatiControl = await SqlDataAccess.GetControlPropertyByID(item.Id);

            ++idCount;
            temp.ProprietatiLabel.IdHtml = idCount;
            ++idCount;
            temp.ProprietatiControl.IdHtml = idCount;

            // Console.WriteLine(temp.ProprietatiLabel.IdHtml + " " + temp.ProprietatiLabel.TopOffset + " " + temp.ProprietatiLabel.Color);

            rows.Add(temp);
        }

        user = await SqlDataAccess.GetSqlUsername();

        editable = true;
    }

    private void CreateNewComponent()
    {
        itemCreation = true;

        // NavigationManager.NavigateTo("/items/new-item");
    }

    private void HandleValidSubmit()
    {
        // generate unique id
        newComponent.Id = GenerateRandomId();

        if (newComponent.Tip == "INT")
        {
            string[] options = newComponent.ValoareString.Split(';');
            newComponent.Valori = new List<int>();

            foreach (var opt in options)
            {
                newComponent.Valori.Add(Int32.Parse(opt));
            }
        }

        newComponent.ValoareInt = -1;

        newComponent.Grupare = rows.ElementAt(0).Grupare;
        newComponent.Activ = -1;
        newComponent.Ordine = rows.Last().Ordine + 1;

        Properties propsLabel = new Properties();
        Properties propsControl = new Properties();

        propsLabel.IdHtml = rows.Last().ProprietatiLabel.IdHtml + 2;
        propsLabel.TopOffset = "0px";
        propsLabel.LeftOffset = "0xp";
        propsLabel.Width = "150px";
        propsLabel.Height = "55px";
        propsLabel.Color = "rgb(255, 255, 255)";
        propsLabel.Border = "1px solid rgba(136, 136, 136, 0.5)";
        propsLabel.FontSize = "16px";
        newComponent.ProprietatiLabel = propsLabel;

        propsControl.IdHtml = rows.Last().ProprietatiControl.IdHtml + 2;
        propsControl.TopOffset = "0px";
        propsControl.LeftOffset = "0xp";
        if (newComponent.Tip == "INT")
        {
            propsControl.Width = "145px";
        }
        else if (newComponent.Tip == "VARCHAR(255)")
        {
            propsControl.Width = "245px";
        }
        else if (newComponent.Tip == "DATETIME")
        {
            propsControl.Width = "195px";
        }
        else
        {
            propsControl.Width = "95px";
        }
        propsControl.Height = "55px";
        propsControl.Color = "rgb(255, 255, 255)";
        propsControl.Border = "1px solid rgba(136, 136, 136, 0.5)";
        propsControl.FontSize = "16px";
        newComponent.ProprietatiControl = propsControl;

        itemCreation = false;
        rows.Add(newComponent);

        newComponent = new ObjModExtended();
    }

    private int GenerateRandomId()
    {
        var exclude = new HashSet<int>();
        foreach (var row in rows)
        {
            exclude.Add(row.Id);
        }

        var range = Enumerable.Range(1, 1000).Where(i => !exclude.Contains(i));

        var rand = new System.Random();
        int index = rand.Next(0, 1000 - exclude.Count);

        // Console.WriteLine(range.ElementAt(index));

        return range.ElementAt(index);
    }

    private async void Edit()
    {
        if (editable)
        {
            var dotNetReference = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("draggable", dotNetReference);

            editNow = true;
            reset = true;

            StateHasChanged();
        }
    }

    private void SaveAllComponents()
    {
        if (editNow || reset)
        {
            foreach (var item in rows)
            {
                // save all changes to db
                SqlDataAccess.UpdateLabelProperty(item.ProprietatiLabel, item.Id);
                SqlDataAccess.UpdateControlProperty(item.ProprietatiControl, item.Id);
            }

            editNow = false;
            reset = false;
        }
    }

    private void ResetAllPositions()
    {
        foreach (var item in rows)
        {
            item.ProprietatiLabel.TopOffset = "0px";
            item.ProprietatiLabel.LeftOffset = "0px";

            item.ProprietatiControl.TopOffset = "0px";
            item.ProprietatiControl.LeftOffset = "0px";
        }

        reset = true;
    }

    [JSInvokable("SavePosition")]
    public void UpdatePosition(string id, string topOffset, string leftOffset, string className)
    {
        int itemID;
        bool res = int.TryParse(id, out itemID);
        if (!res)
        {
            Console.WriteLine("ret1");
            return;
        }

        int dragTopOffset;
        res = int.TryParse(topOffset, out dragTopOffset);
        if (!res)
        {
            Console.WriteLine("ret2");
            return;
        }

        int dragLeftOffset;
        res = int.TryParse(leftOffset, out dragLeftOffset);
        if (!res)
        {
            Console.WriteLine("ret3");
            return;
        }

        int index = 0;
        if (className == "item-label")
        {
            index = rows.FindIndex(x => x.ProprietatiLabel.IdHtml == itemID);
            if (index == -1)
            {
                return;
            }
        }
        else if (className == "item-control")
        {
            index = rows.FindIndex(x => x.ProprietatiControl.IdHtml == itemID);
            if (index == -1)
            {
                return;
            }
        }

        // Console.WriteLine("save: " + itemID + " " + dragTopOffset + " " + dragLeftOffset);

        if (className == "item-label")
        {
            int currentTopOffset = Int32.Parse(rows.ElementAt(index).ProprietatiLabel.TopOffset.Substring(0, rows.ElementAt(index).ProprietatiLabel.TopOffset.Length - 2));
            int currentLeftOffset = Int32.Parse(rows.ElementAt(index).ProprietatiLabel.LeftOffset.Substring(0, rows.ElementAt(index).ProprietatiLabel.LeftOffset.Length - 2));

            int newTopOffset = currentTopOffset + dragTopOffset;
            int newLeftOffset = currentLeftOffset + dragLeftOffset;

            rows.ElementAt(index).ProprietatiLabel.TopOffset = newTopOffset + "px";
            rows.ElementAt(index).ProprietatiLabel.LeftOffset = newLeftOffset + "px";

        }
        else if (className == "item-control")
        {
            int currentTopOffset = Int32.Parse(rows.ElementAt(index).ProprietatiControl.TopOffset.Substring(0, rows.ElementAt(index).ProprietatiControl.TopOffset.Length - 2));
            int currentLeftOffset = Int32.Parse(rows.ElementAt(index).ProprietatiControl.LeftOffset.Substring(0, rows.ElementAt(index).ProprietatiControl.LeftOffset.Length - 2));

            int newTopOffset = currentTopOffset + dragTopOffset;
            int newLeftOffset = currentLeftOffset + dragLeftOffset;


            rows.ElementAt(index).ProprietatiControl.TopOffset = newTopOffset + "px";
            rows.ElementAt(index).ProprietatiControl.LeftOffset = newLeftOffset + "px";
        }
    }

    [JSInvokable("GetDetails")]
    public void DisplayDetails(string id, string className, string width, string height, string top, string left, string color, string border, string fontSize)
    {
        int itemID;
        bool res = int.TryParse(id, out itemID);
        if (!res)
        {
            Console.WriteLine("ret1");
            return;
        }

        int index = 0;
        if (className == "item-label")
        {
            index = rows.FindIndex(x => x.ProprietatiLabel.IdHtml == itemID);
            if (index == -1)
            {
                return;
            }
        }
        else if (className == "item-control")
        {
            index = rows.FindIndex(x => x.ProprietatiControl.IdHtml == itemID);
            if (index == -1)
            {
                return;
            }
        }

        itemDetails.Name = rows.ElementAt(index).Simbol;
        if (className == "item-label")
        {
            itemDetails.Name += " (label)";
        }
        else if (className == "item-control")
        {
            itemDetails.Name += " (control)";
        }

        // Console.WriteLine(id + className + width + height + top + left + color + border + fontSize);

        itemDetails.Id = itemID;
        itemDetails.ClassName = className;
        itemDetails.Width = width;
        itemDetails.Height = height;
        itemDetails.Top = top;
        itemDetails.Left = left;
        itemDetails.Color = color;
        itemDetails.Border = border;
        itemDetails.FontSize = fontSize;

        StateHasChanged();

        // Console.WriteLine(itemDetails.Width + " " + itemDetails.Height + " " + itemDetails.Top + " " + itemDetails.Left + " " + itemDetails.Color + " " + itemDetails.Border);
    }

    private void UpdateProperty(Props propertyName, string value)
    {
        int index;

        if (itemDetails.ClassName == "item-label")
        {
            index = rows.FindIndex(x => x.ProprietatiLabel.IdHtml == itemDetails.Id);
            if (index == -1)
            {
                return;
            }

            rows.ElementAt(index).ProprietatiLabel.SetProperty(propertyName, value);

            Console.WriteLine(propertyName + " " + value);
        }
        else if (itemDetails.ClassName == "item-control")
        {
            index = rows.FindIndex(x => x.ProprietatiControl.IdHtml == itemDetails.Id);
            if (index == -1)
            {
                return;
            }

            rows.ElementAt(index).ProprietatiControl.SetProperty(propertyName, value);

            Console.WriteLine(propertyName + " " + value);
        }
    }

    public void UpdateWidth(string width)
    {
        // await JSRuntime.InvokeVoidAsync("updateWidth", itemDetails.Id, width);

        UpdateProperty(Props.Width, width);
    }

    public void UpdateHeight(string height)
    {
        // await JSRuntime.InvokeVoidAsync("updateHeight", itemDetails.Id, height);

        UpdateProperty(Props.Height, height);
    }

    public void UpdateTop(string top)
    {
        // await JSRuntime.InvokeVoidAsync("updateTop", itemDetails.Id, top);

        UpdateProperty(Props.Top, top);
    }

    public void UpdateLeft(string left)
    {
        // await JSRuntime.InvokeVoidAsync("updateLeft", itemDetails.Id, left);

        UpdateProperty(Props.Left, left);
    }

    public void UpdateColor(string color)
    {
        // await JSRuntime.InvokeVoidAsync("updateColor", itemDetails.Id, color);

        UpdateProperty(Props.Color, color);
    }

    public void UpdateBorder(string border)
    {
        // await JSRuntime.InvokeVoidAsync("updateBorder", itemDetails.Id, border);

        UpdateProperty(Props.Border, border);
    }

    public void UpdateFontSize(string fontSize)
    {
        // await JSRuntime.InvokeVoidAsync("updateFontSize", itemDetails.Id, fontSize);

        UpdateProperty(Props.FontSize, fontSize);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ISqlDataAccess SqlDataAccess { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
