Imports System.Data.SqlClient


Public Class PublicacionesUB_Admin
    Inherits System.Web.UI.Page
    Protected Sub SqlDataSource1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs)

    End Sub
    Dim usuario As String
    Dim avisoID As String
    Dim eliminar As Boolean
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            usuario = Session("stuser")
            CargarRepeater()

        Catch ex As Exception

        End Try

    End Sub
    Private Sub CargarRepeater()
        Try



            Dim cmdCarga As New SqlCommand()
            Dim adapterCarga As New SqlDataAdapter()
            Dim Con2 As New SqlConnection(ConfigurationManager.ConnectionStrings("SubSICAIE_UBConnectionString").ConnectionString.ToString)
            cmdCarga.CommandText = "exec SP_MiWebAdminPublicacionesUB @Usuario"
            Dim seleccionSql As New SqlParameter("@Usuario", SqlDbType.Int)
            seleccionSql.Value = usuario
            cmdCarga.Parameters.Add(seleccionSql)
            cmdCarga.CommandType = CommandType.Text
            cmdCarga.Connection = Con2
            adapterCarga.SelectCommand = cmdCarga
            Dim tablaAvisos As New DataTable()
            adapterCarga.Fill(tablaAvisos)

            RepeaterAdmin.DataSource = tablaAvisos
            RepeaterAdmin.DataBind()

            If (RepeaterAdmin.Items.Count > 0) Then
                pnlDatos.Visible = True
                pnlMensaje.Visible = False
            Else
                pnlDatos.Visible = False
                pnlMensaje.Visible = True
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Function VerificarEliminar(ByVal id As String) As Boolean
        Try

            If id <> "" Then
                Dim cmdCarga As New SqlCommand()
                Dim adapterCarga As New SqlDataAdapter()
                Dim dsResult As New DataSet

                Dim Con2 As New SqlConnection(ConfigurationManager.ConnectionStrings("SubSICAIE_UBConnectionString").ConnectionString.ToString)
                cmdCarga.CommandText = "exec SP_Publicaciones_Eliminar @id"
                Dim seleccionSql As New SqlParameter("@id", SqlDbType.Int)
                seleccionSql.Value = id
                cmdCarga.Parameters.Add(seleccionSql)
                cmdCarga.CommandType = CommandType.Text
                cmdCarga.Connection = Con2
                adapterCarga.SelectCommand = cmdCarga

                adapterCarga.Fill(dsResult)
                Dim resultado As String
                resultado = dsResult.Tables(0).Rows(0).Item(0)
                If resultado = "OK" Then
                    CargarRepeater()
                    Return True

                Else
                    Return False
                End If
            End If
        Catch ex As Exception

        End Try
    End Function


    Protected Sub OnbtnEditarAviso_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim control As Web.UI.WebControls.Button = sender
        Dim id As String
        id = control.CommandArgument.ToString()

        Response.Redirect("PublicacionesUBFormulario.aspx?id=" + id)

    End Sub
    Protected Sub Repeater1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles RepeaterAdmin.ItemCommand

        VerificarEliminar(e.CommandName)

    End Sub
End Class