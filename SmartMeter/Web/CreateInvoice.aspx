<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateInvoice.aspx.cs" Inherits="CreateInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="background-color: white;">
        <table style="width: 100%;">
            <tr>
                <td align="left;">Select type of Service
                </td>
            </tr>
            <tr>
                <td align="left;">
                    <asp:DropDownList ID="ddlService" runat="server" CssClass="DropDown" Width="150">
                        <asp:ListItem Text="Electricity" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView runat="server" ID="gvCustomer" DataKeyNames="CustomerID,MeterID" CellPadding="4" ForeColor="#333333" 
                        AutoGenerateColumns="false" AllowPaging="true" PageSize="10" 
                        OnPageIndexChanged="gvCustomer_PageIndexChanged"
                        GridLines="None" Width="100%">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="MeterID" HeaderText="Meter ID" />
                            <asp:BoundField DataField="Name" HeaderText="Customer Name" />
                            <asp:BoundField DataField="Address" />
                            <asp:BoundField DataField="Pincode" />                            
                            <asp:CheckBoxField HeaderText="Select" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnCreateInvoice" runat="server" OnClick="btnCreateInvoice_Click" CssClass="btnClass" Text="Create Invoice" />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvInvoice" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

