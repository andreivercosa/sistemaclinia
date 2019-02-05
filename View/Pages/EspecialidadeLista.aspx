<%@ Page Language="C#" Inherits="View.Pages.EspecialidadeLista" %>
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