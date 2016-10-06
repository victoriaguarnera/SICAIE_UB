Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net
Imports System.Text.RegularExpressions

Public Class FuncionesWebUB

    'Public Shared Function fnURL(ByVal stURLOrigen As String, ByVal stURLDetino As String) As String
    '    Dim stServerLocal As String
    '    Dim stDestino As String

    '    stDestino = ConfigurationManager.AppSettings("SICAIE_UB_SITIO_WEB")

    '    stServerLocal = ConfigurationManager.AppSettings("SICAIE_UB_SERVER_LOCAL")
    '    If stServerLocal = "" Then stServerLocal = "10.14.0.21"

    '    If InStr(stURLOrigen, stServerLocal) > 0 Or InStr(LCase(stURLOrigen), "localhost") > 0 Then
    '        fnURL = stURLDetino
    '    Else
    '        fnURL = stDestino & stURLDetino
    '    End If
    'End Function

  

    Public Shared Function Fecha_AAAAMMDD2(ByVal stFEcha As String) As String
        Dim dtFEcha As Date

        If stFEcha = "" Then
            Fecha_AAAAMMDD2 = "null"
        Else
            dtFEcha = stFEcha
            Fecha_AAAAMMDD2 = "'" & Right("0000" & DatePart(DateInterval.Year, dtFEcha), 4) & Right("00" & DatePart(DateInterval.Month, dtFEcha), 2) & Right("00" & DatePart(DateInterval.Day, dtFEcha), 2) & "'"
        End If


    End Function

    Public Shared Function Fecha_AAAAMMDD(ByVal stFEcha As String) As String
        Dim dtFEcha As Date

        If stFEcha = "" Then
            Fecha_AAAAMMDD = "null"
        Else
            dtFEcha = stFEcha
            Fecha_AAAAMMDD = "" & Right("0000" & DatePart(DateInterval.Year, dtFEcha), 4) & Right("00" & DatePart(DateInterval.Month, dtFEcha), 2) & Right("00" & DatePart(DateInterval.Day, dtFEcha), 2) & ""
        End If


    End Function

    Public Shared Function ObtenerResultado(ByVal sQuery As String) As String
        Dim stStatus As String = ""
        Dim i As Integer


        Try

            Dim ds As New DataSet
            Dim stResult As String = ""
            ds = GetSQLDataSet(sQuery, stStatus)



            For i = 0 To ds.Tables(0).Rows.Count - 1
                stResult = stResult & ds.Tables(0).Rows(i).Item(0)

            Next
            ObtenerResultado = stResult
        Catch ex As Exception
            ObtenerResultado = ""

        End Try

    End Function

    Public Shared Function fnParametro(ByVal stParametro As String, ByVal stDefault As String) As String

        Dim ds As New Data.DataSet
        'Dim visServices As New visWebClient.DataServices

        Try

            Dim stQuery1 As String = "select * from tblSYSParametros where Parametro='" & stParametro & "'"

            Dim cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("SubSICAIE_UBConnectionString").ConnectionString.ToString)
            cnn.Open()
            Dim da As New SqlDataAdapter
            Dim cmd As New SqlCommand(stQuery1, cnn)
            da.SelectCommand = cmd
            da.Fill(ds)

            If ds.Tables(0).Rows.Count = 0 Then
                fnParametro = stDefault
            Else
                fnParametro = CStr(ds.Tables(0).Rows(0).Item(1))
            End If

            cnn.Close()
            cnn.Dispose()
        Catch
            fnParametro = stDefault

        End Try

    End Function

    Public Shared Function GetSQLDataSet(ByVal stQuery1 As String, ByRef stStatus As String) As Data.DataSet
        Dim ds As New Data.DataSet
        'Dim visServices As New visWebClient.DataServices

        Try



            Dim cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("SICAIE_SYS_ConnectionString").ConnectionString.ToString)
            cnn.Open()
            Dim da As New SqlDataAdapter
            Dim cmd As New SqlCommand(stQuery1, cnn)
            da.SelectCommand = cmd
            da.Fill(ds)

            stStatus = "OK"

            da.Dispose()
            cmd.Dispose()
            cnn.Close()
            cnn.Dispose()

            Return ds
        Catch

            stStatus = Err.Description
        End Try

    End Function

    Public Shared Sub CargarCombo(ByVal Combo As DropDownList, ByVal sQuery As String, ByVal Campo1 As String, ByVal Campo2 As String, ByVal Valor As String)

        Dim stStatus As String = ""
        Dim i As Integer

        Try
            Dim ds As New DataSet

            ds = GetSQLDataSet(sQuery, stStatus)

            ' Combo.Items.Clear()

            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim wcItem As New ListItem
                If CStr(ds.Tables(0).Rows(i).Item(Campo1)) = Valor Then
                    wcItem.Selected = True
                End If
                wcItem.Text = ds.Tables(0).Rows(i).Item(Campo2)
                wcItem.Value = ds.Tables(0).Rows(i).Item(Campo1)
                Combo.Items.Add(wcItem)
            Next

        Catch ex As Exception


        End Try

    End Sub

    Shared Function enviaEmail(ByVal sfrom As String, ByVal sTo As String, ByVal sHost As String, ByVal smtpCredUser As String, ByVal smtpPass As String, ByVal sCodigo As String, ByVal sBody As String, ByVal sSubject As String, Optional ByVal strAttach As String = "") As Boolean
        'Llama relevamiento
        Dim sCuerpo As String = ""
        Dim email As New MailMessage()

        enviaEmail = True
        
        With email
            .From = New MailAddress("SICAIE_UB@comunidad.ub.edu.ar", "Web SICAIE")
       
            .To.Add(sTo)
          

            .Subject = sSubject
            .IsBodyHtml = True
            .Priority = MailPriority.High

            .Body = "" & sBody

        End With
        Dim smtp As New SmtpClient
        smtp.Host = "gmail"
        smtp.Port = 25
       
        Try
            smtp.Send(email)

        Catch ex As Exception
            enviaEmail = False
            sCuerpo = ex.Message
        End Try

    End Function

    Public Shared Function CambiarFuentes(ByVal st As String) As String
        st = st.Replace("<head>", "<head><link href='http://fonts.googleapis.com/css?family=Raleway:400,200,700' rel='stylesheet' type='text/css'>")
        st = st.Replace("font-family:", "font-family:'Raleway'; otro:")
        Return st
    End Function

   

    
  

    
    'nuevas funciones
    Public Shared Function EsKiosco(ByVal st As String) As Boolean
        If st <> "" AndAlso st.IndexOf("KIOSCO") >= 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Function AnularLinks(ByRef st As String) As String

        st = st.Replace("href=" & Chr(34) & "mailto:", "href=" & Chr(34) & "#")
        st = st.Replace("href=" & Chr(34) & "http", "href=" & Chr(34) & "#")
        st = st.Replace("href=" & Chr(34) & "HTTP", "href=" & Chr(34) & "#")
        st = st.Replace("href=" & Chr(34) & "www", "href=" & Chr(34) & "#")
        st = st.Replace("href=" & Chr(34) & "WWW", "href=" & Chr(34) & "#")
        st = st.Replace("target=" & Chr(34) & "_blank" & Chr(34), "target=" & Chr(34) & Chr(34))
        ParamCanalPF(st)
        Return st
    End Function

    Public Shared Function ParamCanalPF(ByRef st As String) As String

        If EsKiosco(System.Web.HttpContext.Current.Session("CANAL")) Then
            st = st.Replace("PARAM_CANAL", "#toolbar=0&amp;navpanes=0")
        Else
            st = st.Replace("PARAM_CANAL", "")
        End If

        Return st
    End Function

    Public Shared Function LinkCanal(ByVal varCanal As String, ByVal link As String) As String
        'funcion llamada desde asp
        If EsKiosco(varCanal) Then
            link = link.Replace("http", "#")
            link = link.Replace("www", "#")
        End If
        Return link
    End Function

    Public Shared Function TargetCanal(ByVal varCanal As String) As String
        'funcion llamada desde asp
        If EsKiosco(varCanal) Then
            Return ""
        End If
        Return "_blanck"
    End Function

    Public Shared Function LlamarPF(ByVal varCanal As String, ByVal strPdf As String, ByVal num As Double) As String
        'funcion llamada desde asp
        If EsKiosco(varCanal) Then
            Return "javascript:$.prettyPhoto.open('" & strPdf & "#toolbar=0&navpanes=0&amp;iframe=true&amp;&amp;width=880&amp;height=520', '', '');"
        End If
        Return "javascript:$.prettyPhoto.open('" & strPdf & "&amp;iframe=true&amp;&amp;width=880&amp;height=520', '', '');"
    End Function

End Class
