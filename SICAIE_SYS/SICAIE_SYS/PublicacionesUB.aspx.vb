Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports SICAIE_SYS.FuncionesWebUB

Partial Public Class PublicacionesUB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'cargaDatos("Select *  from tblPublicaciones where Tipopublicacion=1 order by id desc", 1, 50, DataList1)
        'cargaDatos("Select tblpublicaciones.*, tblSYSUsuarios.Nombre  from tblPublicaciones INNER JOIN tblSYSUsuarios ON tblPublicaciones.Usuario = tblSYSUsuarios.Usuario where Tipopublicacion=1  and Estado=2  order by tblpublicaciones.id desc", 1, 150, DataList1)
        cargaDatos("exec SP_UB_Publicaciones_Traer", 1, 150, DataList1)

    End Sub
    Private Sub cargaDatos(ByVal stQuery As String, ByVal iPaginaActual As Integer, ByVal iCantidadMostrar As Integer, ByRef objData As DataList)
        Dim sSql As String
        Dim da As New SqlDataAdapter
        Dim cmd As New SqlCommand()
        Dim dsResult As New DataSet
        Dim dsBusqueda As New DataSet
        Dim objPds = New PagedDataSource()
        'Try

        Using UBConn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("SICAIE_SYS_ConnectionString").ConnectionString.ToString)

            UBConn.Open()

            cmd.CommandText = stQuery
            cmd.CommandType = CommandType.Text
            cmd.Connection = UBConn

            da.SelectCommand = cmd

            da.Fill(dsResult)


            'lblPaginaActual.Text = ""
            'objPds.DataSource = dsResult.Tables(0).DefaultView
            'objPds.AllowPaging = True

            objData.DataSource = dsResult.Tables(0).DefaultView 'objPds
            objData.DataBind()
            UBConn.Close()

        End Using


    End Sub
    Public Function fnVLObtenerImagenes(ByVal stID) As String

        Dim da As New SqlDataAdapter
        Dim cmd As New SqlCommand()
        Dim dsResult As New DataSet
        Dim dsBusqueda As New DataSet
        Dim objPds = New PagedDataSource()
        Dim stParh As String
        'Try
        Dim stVilla As String = ""
        Using RRHHConn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("SICAIE_SYS_ConnectionString").ConnectionString.ToString)

            RRHHConn.Open()

            cmd.CommandText = "Select * from tblPublicacionesFotos where IDPublicacion=" & stID
            cmd.CommandType = CommandType.Text
            cmd.Connection = RRHHConn

            da.SelectCommand = cmd

            da.Fill(dsResult)

            If WebConfigurationManager.AppSettings("CTE_URL_CARTELERA_FOTO") = "" Then
                stParh = "Cartelera/Fotos/"
            Else
                stParh = WebConfigurationManager.AppSettings("CTE_URL_CARTELERA_FOTO")
            End If


            stVilla = ""
            For i = 0 To dsResult.Tables(0).Rows.Count - 1
                Dim stFile As String = stParh & dsResult.Tables(0).Rows(i).Item("archivo")
                If WebConfigurationManager.AppSettings("CTE_URL_CARTELERA_FOTO_SIN_LINK") = "Y" Then
                    stVilla = stVilla & "<img class='FotoCarteleraAviso'  src='" & stFile & "'>"
                Else
                    If Not WebConfigurationManager.AppSettings("CTE_URL_CARTELERA_FOTO_SIN_PRETTY") = "N" Then
                        '
                        stVilla = stVilla & "<a href='" & stFile & "'  rel='prettyPhoto[gallery" & stID & "]'><img class='FotoCarteleraAviso'  src='" & stParh & dsResult.Tables(0).Rows(i).Item("archivo") & "'></a>"
                    Else
                        stVilla = stVilla & "<a href='" & stFile & "'  target=_blank><img class='FotoCarteleraAviso'  src='" & stParh & dsResult.Tables(0).Rows(i).Item("archivo") & "'></a>"
                    End If

                End If


            Next
            fnVLObtenerImagenes = stVilla

            RRHHConn.Close()

        End Using

    End Function

End Class