<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Index.ascx.cs" Inherits="CMS.Index" %>
<%@ Register Assembly="CMSClassLibrary" Namespace="CMSClassLibrary.Components" TagPrefix="cc1" %>
<%-- <% //CMSClassLibrary.TemplateManagement.TemplateManager s = new CMSClassLibrary.TemplateManagement.TemplateManager();
         //  s.Render(this.Page); 
            %>--%>
<div class="body">
    <div id="b_holder" class="container">
        <div class="container_nav_outer">
            <div class="container">
                <div class="row-fluid">
                    <asp:PlaceHolder ID="Logo1" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="TitlePlace" runat="server"><span style="font-size: 18px"></span></asp:PlaceHolder>
                    <div style="float: left">
                        <asp:PlaceHolder ID="Logo2" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </div>
        </div>
        <div class="container_outer_pathway">
            <div class="container">
                <div class="row-fluid">
                    <ul class="breadcrumb">
                        <%--<li class="showHere">شما اینجا هستید : </li>--%>
                        <li class="active">خانه</li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="container_nav_outer">
            <div class="container">
                <div class="row-fluid">
                    <div id="hor_nav">
                        <asp:PlaceHolder ID="menuPlace" runat="server"></asp:PlaceHolder>
                        <%--<div class="search">
                            <label class="element-invisible" for="mod-search-searchword">Search...</label>
                            <input id="mod-search-searchword" class="inputbox search-query" type="text" 
                                onfocus="if (this.value=='Search...') this.value='';" onblur="if (this.value=='') this.value='Search...';" 
                                value="Search..." size="20" maxlength="20" name="searchword" />
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="container_nav_outer">
            <div class="container">
                <div class="row-fluid">
                    <div id="sidebar" class="span3">
                        <div class="sidebar-nav">
                            <div class="well">
                                <div id="page_header_h3" class="page-header">
                                    <asp:Label ID="Loginlbl" runat="server"></asp:Label>
                                </div>
                                <div class="custom">
                                    <asp:PlaceHolder ID="loginPlace" runat="server"></asp:PlaceHolder>

                                </div>
                            </div>
                            <div class="well">
                                <div id="page_header_h3" class="page-header">
                                    <asp:Label ID="esteellbl" runat="server"></asp:Label>
                                </div>
                                <div class="custom">
                                    
                                    <span style="line-height: 1.3em;">
                                       <asp:PlaceHolder ID="Side1" runat="server"></asp:PlaceHolder>
                                    </span>
                                </div>
                            </div>
                            <div class="well">
                                <div id="page_header_h3" class="page-header">
                                    <asp:Label ID="Rahatilbl" runat="server"></asp:Label>
                                </div>
                                <div class="custom">
                                    <span style="line-height: 1.3em;">
                                        <asp:PlaceHolder ID="Side2" runat="server"></asp:PlaceHolder>
                                    </span>
                                </div>
                            </div>
                            <div class="well">
                                <div id="page_header_h3" class="page-header">
                                    <asp:Label ID="khablbl" runat="server"></asp:Label>
                                </div>
                                <div class="custom">
                                    <span style="line-height: 1.3em;">
                                        <asp:PlaceHolder ID="Side3" runat="server"></asp:PlaceHolder>
                                    </span>
                                </div>
                            </div>
                            <%-- <div class="well">
                                <div id="page_header_h3" class="page-header">
                                    <asp:Label ID="Edarilbl" runat="server"></asp:Label>
                                </div>
                                <div class="custom">

                                    <span style="line-height: 1.3em;">some text some text
                                    </span>
                                </div>
                            </div>--%>
                        </div>
                    </div>
                    <div id="content" class="span9">
                        <div class="loading" style="display:none"><img src="Images/ajax-loader.gif" /></div>
                        <div id="slide-wrap">
                            <asp:PlaceHolder ID="sliderPlace" runat="server"></asp:PlaceHolder>
                        </div>
                        <div class="outer_tabs">
                            <div class="well " id="mainContent">
                                <asp:PlaceHolder ID="signupPlace" runat="server">
                                    
                                </asp:PlaceHolder>


                            </div>
                            
                            <asp:PlaceHolder ID="infoPlace" runat="server">
                                <div id="featured-row">
                                    <div class="frow">
                                        <div class="moduletable">
                                            <h3 class="module_title ">Cases</h3>
                                            <div class="mod-newsflash mod-newsflash__">
                                                <div class="item">
                                                    <p id="system-readmore">
                                                        خط مشی ما تولید مبتنی بر اصول دقیق ارگونومی است. تحقیقات بسیار زیادی توسط متخصصان ما صورت گرفته است تا شکل ایده آل ستون فقرات و همچنین زوایای مناسب برای بدن انسان تعین شود. طراحی های ما بر اساس قد و وزن غالب جامعه ایران است.. طبیعی است که با توجه به هدفی که ما برای خود برگزیده ایم، تنوع محصولات موراشین بالا نباشد. با این حال طراحان ما با تلفیق طراحی مدرن و سنتی که مطابق با طبع جامعه ایرانی است کوشیده اند ظاهری قابل قبول و شکیل را در نهایت سادگی فراهم آورند.
                                                    </p>
                                                    <a href="#" class="readmore" onclick="dispatchMenuEvent(this);return false;" itemid="25">Read more...</a>
                                                </div>
                                            </div>
                                        </div>
                                       
                                    </div>
                                </div>
                            </asp:PlaceHolder>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="container_nav_outer">
            <div id="footer">
                <div id="footer-row">
                    <div class="frow">
                        <div class="footer-row-1">
                            <div class="footer-col">
                                درباره ما
                            </div>
                            <div class="footer-col">
                                <div>ارتباط با ما</div>
                                
                            </div>
                            <div class="footer-col">
                                <div>
                                    <img src="Images/ico.facebook.png" width="32" height="32" />
                                    <img src="Images/ico.twitter.png" width="32" height="32" />
                                    <img src="Images/ico.linkedin.png" width="32" height="32" />
                                    <img src="Images/ico.youtube.png" width="32" height="32" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</div>

