#pragma checksum "C:\Users\Jose David\source\repos\GYM\GYM\Areas\Receptionist\Views\User\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2abd2d7af799a20e81cd5896521899f0d0970577"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Receptionist_Views_User_Details), @"mvc.1.0.view", @"/Areas/Receptionist/Views/User/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2abd2d7af799a20e81cd5896521899f0d0970577", @"/Areas/Receptionist/Views/User/Details.cshtml")]
    public class Areas_Receptionist_Views_User_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GYM.Models.ApplicationUser>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Jose David\source\repos\GYM\GYM\Areas\Receptionist\Views\User\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>User</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "C:\Users\Jose David\source\repos\GYM\GYM\Areas\Receptionist\Views\User\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "C:\Users\Jose David\source\repos\GYM\GYM\Areas\Receptionist\Views\User\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "C:\Users\Jose David\source\repos\GYM\GYM\Areas\Receptionist\Views\User\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "C:\Users\Jose David\source\repos\GYM\GYM\Areas\Receptionist\Views\User\Details.cshtml"
       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "C:\Users\Jose David\source\repos\GYM\GYM\Areas\Receptionist\Views\User\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IDCard));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "C:\Users\Jose David\source\repos\GYM\GYM\Areas\Receptionist\Views\User\Details.cshtml"
       Write(Html.DisplayFor(model => model.IDCard));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "C:\Users\Jose David\source\repos\GYM\GYM\Areas\Receptionist\Views\User\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "C:\Users\Jose David\source\repos\GYM\GYM\Areas\Receptionist\Views\User\Details.cshtml"
       Write(Html.DisplayFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "C:\Users\Jose David\source\repos\GYM\GYM\Areas\Receptionist\Views\User\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RegistrationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "C:\Users\Jose David\source\repos\GYM\GYM\Areas\Receptionist\Views\User\Details.cshtml"
       Write(Html.DisplayFor(model => model.RegistrationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "C:\Users\Jose David\source\repos\GYM\GYM\Areas\Receptionist\Views\User\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "C:\Users\Jose David\source\repos\GYM\GYM\Areas\Receptionist\Views\User\Details.cshtml"
       Write(Html.DisplayFor(model => model.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    <div class=\"row mt-5\">\r\n        <div class=\"col\">\r\n            <a asp-action=\"Upsert\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1556, "\"", 1580, 1);
#nullable restore
#line 55 "C:\Users\Jose David\source\repos\GYM\GYM\Areas\Receptionist\Views\User\Details.cshtml"
WriteAttributeValue("", 1571, Model.Id, 1571, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary form-control\">Edit</a>\r\n        </div>\r\n        <div class=\"col\">\r\n            <a asp-action=\"Index\" class=\"btn btn-success form-control\">Back to List</a>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GYM.Models.ApplicationUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
