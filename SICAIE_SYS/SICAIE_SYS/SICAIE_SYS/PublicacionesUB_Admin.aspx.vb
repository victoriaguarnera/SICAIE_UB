﻿Imports System.Data.SqlClient


Public Class PublicacionesUB_Admin
    Inherits System.Web.UI.Page
    Protected Sub SqlDataSource1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs)

    End Sub
    Dim usuario As String
    Dim avisoID As String
    Dim eliminar As Boolean
    Dim UserId, UserType As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            UserId = Session("stUser")
            UserType = Session("stType")
            'usuario = Session("stuser")
            If UserType <> 0 Then
                pnlDatos.Visible = False
                pnlMensaje.Visible = True
                LabelMsj1.Visible = False
                LabelMsj2.Visible = True
            Else
                CargarRepeater()
            End If



        Catch ex As Exception

        End Try

    End Sub
    Private Sub CargarRepeater()
        Try



            Dim cmdCarga As New SqlCommand()
            Dim adapterCarga As New SqlDataAdapter()
            Dim Con2 As New SqlConnection(ConfigurationManager.ConnectionStrings("SICAIE_SYS_ConnectionString").ConnectionString.ToString)
            cmdCarga.CommandText = "exec SP_UB_Publicaciones_Traer_Verificar"
           
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
                LabelMsj1.Visible = True
                LabelMsj2.Visible = False
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

                Dim Con2 As New SqlConnection(ConfigurationManager.ConnectionStrings("SICAIE_SYS_ConnectionString").ConnectionString.ToString)
                cmdCarga.CommandText = "exec SP_UB_Publicaciones_Cambiar_Estado  @id ,@idusr,@estado"
                Dim seleccionSql As New SqlParameter("@id", SqlDbType.Int)
                seleccionSql.Value = id
                cmdCarga.Parameters.Add(seleccionSql)
                Dim seleccionSql2 As New SqlParameter("@idusr", SqlDbType.Int)
                seleccionSql2.Value = UserId
                cmdCarga.Parameters.Add(seleccionSql2)
                Dim seleccionSql3 As New SqlParameter("@estado", SqlDbType.Int)
                seleccionSql3.Value = 0  'estado eliminada 
                cmdCarga.Parameters.Add(seleccionSql3)
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
        id = control.CommandName.ToString()
        'HACER CODIGO PARA ESTO
        Response.Redirect("PublicacionesUB_Formulario.aspx?id=" + id)

    End Sub
    Protected Sub OnbtnRevisarPublicacion_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim control As Web.UI.WebControls.Button = sender
        Dim id As String
        id = control.CommandArgument.ToString()
        Try

            If id <> "" Then
                Dim cmdCarga As New SqlCommand()
                Dim adapterCarga As New SqlDataAdapter()
                Dim dsResult As New DataSet

                Dim Con2 As New SqlConnection(ConfigurationManager.ConnectionStrings("SICAIE_SYS_ConnectionString").ConnectionString.ToString)
                cmdCarga.CommandText = "exec SP_UB_Publicaciones_Cambiar_Estado  @id ,@idusr,@estado"
                Dim seleccionSql As New SqlParameter("@id", SqlDbType.Int)
                seleccionSql.Value = id
                cmdCarga.Parameters.Add(seleccionSql)
                Dim seleccionSql2 As New SqlParameter("@idusr", SqlDbType.Int)
                seleccionSql2.Value = UserId
                cmdCarga.Parameters.Add(seleccionSql2)
                Dim seleccionSql3 As New SqlParameter("@estado", SqlDbType.Int)
                seleccionSql3.Value = 3 'estado Revision
                cmdCarga.Parameters.Add(seleccionSql3)
                cmdCarga.CommandType = CommandType.Text
                cmdCarga.Connection = Con2
                adapterCarga.SelectCommand = cmdCarga

                adapterCarga.Fill(dsResult)
                Dim resultado As String
                resultado = dsResult.Tables(0).Rows(0).Item(0)
                If resultado = "OK" Then

                    ClientScript.RegisterStartupScript(Me.GetType(), "script", "<script>alert('La noticia fue enviada a revisión.');</script>")
                    CargarRepeater()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub OnbtnAprobarPublicacion_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim control As Web.UI.WebControls.Button = sender
        Dim id As String
        id = control.CommandArgument.ToString()
        Try

            If id <> "" Then
                Dim cmdCarga As New SqlCommand()
                Dim adapterCarga As New SqlDataAdapter()
                Dim dsResult As New DataSet

                Dim Con2 As New SqlConnection(ConfigurationManager.ConnectionStrings("SICAIE_SYS_ConnectionString").ConnectionString.ToString)
                cmdCarga.CommandText = "exec SP_UB_Publicaciones_Cambiar_Estado  @id ,@idusr,@estado"
                Dim seleccionSql As New SqlParameter("@id", SqlDbType.Int)
                seleccionSql.Value = id
                cmdCarga.Parameters.Add(seleccionSql)
                Dim seleccionSql2 As New SqlParameter("@idusr", SqlDbType.Int)
                seleccionSql2.Value = UserId
                cmdCarga.Parameters.Add(seleccionSql2)
                Dim seleccionSql3 As New SqlParameter("@estado", SqlDbType.Int)
                seleccionSql3.Value = 2 'estado aprobada
                cmdCarga.Parameters.Add(seleccionSql3)
                cmdCarga.CommandType = CommandType.Text
                cmdCarga.Connection = Con2
                adapterCarga.SelectCommand = cmdCarga

                adapterCarga.Fill(dsResult)
                Dim resultado As String
                resultado = dsResult.Tables(0).Rows(0).Item(0)
                If resultado = "OK" Then

                    ClientScript.RegisterStartupScript(Me.GetType(), "script", "<script>alert('La Noticia ya esta disponible al publico.');</script>")
                    CargarRepeater()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub Repeater1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles RepeaterAdmin.ItemCommand

        VerificarEliminar(e.CommandName)

    End Sub
End Class