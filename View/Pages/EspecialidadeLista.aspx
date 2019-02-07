﻿<%@ Page Language="C#" Inherits="View.Pages.EspecialidadeLista" %>
<!DOCTYPE html>
<html>
    <head runat="server">
        <title>Default</title>
        <link type="text/css" rel="stylesheet" href="../Content/bootstrap.css" />
        <style>
            .posicaoButton{
                
                margin-top: 20px;

            }
        </style>
        
    </head>
    <body>
        <div class="container">
          <!-- #include file ="../menu.inc" -->
          
            <form id="principal" runat="server" class="form-horizontal">
               <div class="form-group">
                    <div class="col-lg-12">
                     <div class="input-group">
                       <asp:Textbox runat="server" id="nome" autocomplete="off" placeholder="Digite a Especialidade" CssClass="form-control"/>
                       <span class="input-group-btn">
                         <asp:Button runat="server" id="btnPesquisar" Text="Pesquisar" CssClass="btn btn-default" OnClick="btnPesquisarEspecialidade" />
                       </span>
                     </div>
                   </div>
                 </div>
                
                <asp:GridView runat="server" id="gridListaEspecialidade" AutoGenerateColumns = "false" CssClass="table table-bordered table-hover">
               <Columns>
                    <asp:BoundField DataField="descricao" HeaderText="ESPECIALIDADE" />
                    <asp:BoundField DataField="dtCadastro" HeaderText="DTCADASTRO" >
                    <ItemStyle Width="10%"> </ItemStyle>
                    </asp:BoundField>
                            
               </Columns>
               </asp:GridView>
            </form>   
       
        </div> 
        <script src="../Scripts/jquery-1.9.1.js"></script>
        <script src="../Scripts/bootstrap.js"></script>
    </body>
</html>