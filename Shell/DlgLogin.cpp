// DlgLogin.cpp : ʵ���ļ�
//

#include "stdafx.h"
#include "Shell.h"
#include "DlgLogin.h"
#include "afxdialogex.h"
#include <afxinet.h>  
#include <afx.h>

// CDlgLogin �Ի���

IMPLEMENT_DYNAMIC(CDlgLogin, CDialog)

CDlgLogin::CDlgLogin(CWnd* pParent /*=NULL*/)
	: CDialog(CDlgLogin::IDD, pParent)
{

}

CDlgLogin::~CDlgLogin()
{
}

void CDlgLogin::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CDlgLogin, CDialog)
	ON_BN_CLICKED(IDOK, &CDlgLogin::OnBnClickedOk)
	ON_BN_CLICKED(IDC_BTN_REGESITER, &CDlgLogin::OnBnClickedBtnRegesiter)
	ON_BN_CLICKED(IDC_BUTTON1, &CDlgLogin::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON2, &CDlgLogin::OnBnClickedButton2)
END_MESSAGE_MAP()


// CDlgLogin ��Ϣ�������


void CDlgLogin::OnBnClickedOk()
{
	// TODO: Add your control notification handler code here 
	CString m_strUser,m_strPassword,m_strCookies,m_strClientKey,m_strCode;
	GetDlgItemText (IDC_TXTUSERNAME,m_strUser );
	GetDlgItemText (IDC_TXTPASSWORD,m_strPassword );
	CString info;
	if(m_strUser.IsEmpty())  
	{  
		MessageBox(_T("�û�������Ϊ�գ�"),_T("��ʾ"),MB_ICONERROR | MB_OK);  
		(CEdit*)GetDlgItem(IDC_TXTUSERNAME)->SetFocus();   
		return;  
	}  
	if( m_strPassword.IsEmpty())  
	{  
		MessageBox(_T("���벻��Ϊ�գ�"),_T("��ʾ"),MB_ICONERROR | MB_OK);  
		(CEdit*)GetDlgItem(IDC_TXTPASSWORD)->SetFocus();   
		return;  
	}  
	CWebProcess web;
	bool result=web.Login (m_strUser ,m_strPassword ,info);
	MessageBox (info);
	if(result)
	{
		m_QQ =m_strUser ;
		m_password =m_strPassword ;
		CStdioFile file;
		CString path="D:\\ǧ�������.dat";
		if(file.Open (path,CStdioFile::modeCreate|CStdioFile::modeWrite  ))
		{
			file.WriteString (m_strUser );
			file.WriteString ("\r\n");
			file.WriteString (m_strPassword );
			
		}
		file.Close ();
		EndDialog (IDOK);
	}

}


void CDlgLogin::OnBnClickedBtnRegesiter()
{
	CString result;CString info;
	CString userName;
	CString password;
	CString password2;
	CString tuijianren;
	GetDlgItemText(IDC_TXTNEWUSER,userName );
	GetDlgItemText(IDC_TXTNEWPASSWORD,password);
	GetDlgItemText(IDC_TXTNEWPASSWORD2,password2);
	GetDlgItemText(IDC_TXTTUIJIANREN,tuijianren);

	if(password.GetLength ()<1|| password .GetLength ()>15)
	{
		MessageBox (_T("���벻��Ϊ���Ҳ��ܴ���15λ��"));
		return;
	}
	if(password!=password2)
	{
		MessageBox (_T("�����ظ�����ͬ��"));
		return;
	}

	if(userName .GetLength ()>11)
	{
		MessageBox (_T("��������ȷ��QQ���룡"));
		return;
	}
	if(tuijianren .GetLength ()>11)
	{
		MessageBox (_T("��������ȷ���Ƽ���QQ���룡"));
		return;
	}
	CString mac;
	bool r=GetMacByCmd(mac);
//	MessageBox (mac);
		CString str;  
		try  
	{  
		CInternetSession Session ;   
		CHttpConnection *pHttpConnect = Session.GetHttpConnection(_T("haishengtang.52.xindns4.info")) ;  
		if( pHttpConnect )  
		{  
			CHttpFile* pFile = pHttpConnect->OpenRequest( CHttpConnection::HTTP_VERB_POST ,   
				_T("/Register.aspx"),  
				NULL,  
				1,  
				NULL,  
				NULL,  
				INTERNET_FLAG_NO_COOKIES );  



			//CString strKey  = m_strCookies;  
			//int     result  = strKey.Find(_T("ClientKey="),0);  
			//m_strClientKey  = strKey.Mid(result+10);  

			CString szFormData = _T("__VIEWSTATE=%2FwEPDwUJNDAzNjY0MzE1ZGT2%2BeAyTHNSiPPE2o8Lvv9h3%2B2Vhg%3D%3D&__EVENTVALIDATION=%2FwEWBwKdus3IDwK21fSdDAK1qbSRCwK1qczyCwL6zezYAwLo4b6%2BDAKH%2B8L8DFtLNC90%2FxkaGTu2lIg8pO8dF57f&txtQQNO="+userName +"&txtPassword="+password+"&txtPassword2="+password+"&txtTuijian="+tuijianren+"&BTsubmit=&txtMac="+mac);  
			if (pFile)  
			{     
				pFile->AddRequestHeaders(_T("POST /Register.aspx HTTP/1.1"));  
				pFile->AddRequestHeaders(_T("Pragma: no-cache"));  
				pFile->AddRequestHeaders(_T("Accept: text/html, application/xhtml+xml, */*"));  
				pFile->AddRequestHeaders(_T("Accept-Encoding: gzip, deflate")); 
				pFile->AddRequestHeaders(_T("Accept-Language: zh-CN"));  
				pFile->AddRequestHeaders(_T("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)"));  
				/*pFile->AddRequestHeaders(_T("Cookie: jifenqq=164981897; ASP.NET_SessionId=obf55l55ejlsr245ct4h0d45"));   */
				pFile->AddRequestHeaders(_T("Content-Type: application/x-www-form-urlencoded"));  
				pFile->AddRequestHeaders(_T("Referer: http://haishengtang.52.xindns4.info/Register.aspx"));  
				pFile->AddRequestHeaders(_T("Connection:   Keep-Alive"));  
				pFile->AddRequestHeaders(_T("Host: haishengtang.52.xindns4.info"));  		
				//   pFile->AddRequestHeaders(szFormData);  
				//  pFile->add


				pFile->SendRequestEx (szFormData.GetLength ());
				pFile->WriteString(szFormData);              
				pFile->EndRequest ();
				// ���ص�HTML  
				CString s ;  
				while (pFile->ReadString(s))  
					str += s ;  
				//MessageBox(str);  

				CString temp,m_strCookies; 
				DWORD index=0; 
				while(pFile->QueryInfo(HTTP_QUERY_SET_COOKIE,temp,&index))
				{     
					m_strCookies=m_strCookies+temp;     
				} 



				pFile->Close();  
				delete pFile ;  
				//   pFile->getco

				// ��ȡCOOKIE ClientKeyֵ  
				//CInternetSession    Session;  
				//Session.OpenURL (_T("http://haishengtang.52.xindns4.info/"));
				//if(!Session.GetCookie(_T("http://haishengtang.52.xindns4.info/"),  
				// _T("jifenqq"),m_strCookies))  
				//{  
				// DWORD s=GetLastError ();
				// MessageBox(_T("��ȡCookiesʱ����")); // ERROR_NO_MORE_ITEMS  
				// return;  
				//}  
			}  

			pHttpConnect->Close() ;  
			delete pHttpConnect ;  
		}  
		wchar_t*    pWChar = NULL;  
		DWORD       nLen1;  

		// ��������ҳUTF-8��ʽ����ת����Unicode  
		//LPCSTR pcBuffer;
		// strcpy( pcBuffer , str.GetBuffer(0) );//������һ��
		nLen1   = MultiByteToWideChar(CP_UTF8,0,str,str.GetLength(),pWChar,0);  
		pWChar  = new wchar_t[nLen1 + 1];  
		memset(pWChar,0,(nLen1 + 1 ) * sizeof(wchar_t));  
		MultiByteToWideChar(CP_UTF8,0,str,str.GetLength(),pWChar,nLen1);  

		char*   pChar = NULL;  
		DWORD   nLen2;  

		nLen2 = WideCharToMultiByte(CP_ACP,0,pWChar,nLen1,pChar,0,NULL,NULL);   
		pChar = new char[nLen2 + 1];  
		memset(pChar,0, nLen2 + 1);  
		WideCharToMultiByte(CP_ACP,0,pWChar,nLen1,pChar,nLen2,NULL,NULL);  

		// ���ҵ�¼ʱ������ʱ���ص���Ϣ  
		str.Format(_T("%s"),pChar);  
		 result=str.Mid (0,1);
		 info=str.Mid(1);
		//MessageBox(str);  
	}  
	catch( CInternetException *e )  
	{  
		e->Delete();      
	}  
	if(result ==_T("1"))
	{
		MessageBox(info);  
	}
	else if(result==_T("0"))
	{
		MessageBox(info);  
		return;
	}
	else	
	{
		MessageBox(_T("�����쳣���޷����ӷ�������"));  
		return;
	}
}

bool CDlgLogin::GetMacByCmd( CString &strMac )

{

	const long MAX_COMMAND_SIZE = 10000;

	//��ȡMAC��������

	char szFetCmd[] = "ipconfig /all";

	//����MAC��ַ��ǰ����Ϣ

	const CString str4Search = "Physical Address. . . . . . . . . : ";
	const CString strWIN7search="�����ַ. . . . . . . . . . . . . :";

	strMac = "";

	BOOL bRet;

	SECURITY_ATTRIBUTES sa;

	HANDLE hReadPipe , hWritePipe;



	sa.nLength = sizeof( SECURITY_ATTRIBUTES );

	sa.lpSecurityDescriptor = NULL;

	sa.bInheritHandle = TRUE;



	//�����ܵ�

	bRet = CreatePipe( &hReadPipe , &hWritePipe , &sa , 0 );

	if( !bRet )

	{

		return false;

	}

	//���������д�����Ϣ

	STARTUPINFO si;

	//���ؽ�����Ϣ

	PROCESS_INFORMATION pi;

	si.cb = sizeof( STARTUPINFO );

	GetStartupInfo( &si );

	si.hStdError = hWritePipe;

	si.hStdOutput = hWritePipe;

	//���������д���

	si.wShowWindow = SW_HIDE;

	si.dwFlags = STARTF_USESHOWWINDOW | STARTF_USESTDHANDLES;



	//������ȡ�����н���

	bRet = CreateProcess( NULL , szFetCmd , NULL , NULL , TRUE , 0 , NULL , NULL , &si , &pi );

	//�������������������

	char szBuffer[ MAX_COMMAND_SIZE + 1 ];

	CString strBuffer;

	if( bRet )

	{

		WaitForSingleObject( pi.hProcess , INFINITE );

		unsigned long count;

		CloseHandle( hWritePipe );



		memset( szBuffer , 0x00 , sizeof( szBuffer ) );

		bRet = ReadFile( hReadPipe , szBuffer , MAX_COMMAND_SIZE , &count , 0 ); 

		if( !bRet )
		{
			//�ر����еľ��

			CloseHandle( hWritePipe );

			CloseHandle( pi.hProcess );

			CloseHandle( pi.hThread );

			CloseHandle( hReadPipe );

			return false;
		}

		else

		{

			strBuffer = szBuffer;

			long ipos;

			ipos = strBuffer.Find( str4Search );
			if(ipos==-1)
			{
				ipos = strBuffer.Find( strWIN7search );
				strBuffer = strBuffer.Right( strBuffer.GetLength() - strWIN7search.GetLength() - ipos-1 );
			}
			else
			{
				strBuffer = strBuffer.Right( strBuffer.GetLength() - str4Search.GetLength() - ipos-1 );
			}
			strBuffer = strBuffer.Left( 17 );
			strMac=strBuffer ;
			//for( int i = 0 ; i < strBuffer.GetLength() ; i++ )

			//{

			//       if( strBuffer.GetAt( i ) != '-' )

			//       {

			//              strMac.AppendChar( strBuffer.GetAt( i ) );

			//       }

			//}

			return true;

		}

	}
	else
	{
		return false;
	}
}

void CDlgLogin::OnBnClickedButton1()
{
	GetDlgItem (IDC_STATIC1)->ShowWindow(SW_SHOW);
	GetDlgItem (IDC_STATIC2)->ShowWindow(SW_SHOW);
	GetDlgItem (IDC_STATIC3)->ShowWindow(SW_SHOW);
	GetDlgItem (IDC_STATIC4)->ShowWindow(SW_SHOW);
	GetDlgItem (IDC_STATIC5)->ShowWindow(SW_SHOW);
	GetDlgItem (IDC_STATIC6)->ShowWindow(SW_SHOW);
	GetDlgItem (IDC_STATIC7)->ShowWindow(SW_SHOW);

	GetDlgItem (IDC_TXTNEWUSER)->ShowWindow(SW_SHOW);
	GetDlgItem (IDC_TXTNEWPASSWORD)->ShowWindow(SW_SHOW);
	GetDlgItem (IDC_TXTNEWPASSWORD2)->ShowWindow(SW_SHOW);
	GetDlgItem (IDC_TXTTUIJIANREN)->ShowWindow(SW_SHOW);
	GetDlgItem (IDC_BUTTON2)->ShowWindow(SW_SHOW);
	GetDlgItem (IDC_STATIC10)->ShowWindow(SW_HIDE);
	GetDlgItem (IDC_STATIC8)->ShowWindow(SW_HIDE);
	GetDlgItem (IDC_STATIC9)->ShowWindow(SW_HIDE);

	GetDlgItem (IDC_TXTPASSWORD)->ShowWindow(SW_HIDE);
	GetDlgItem (IDC_TXTUSERNAME)->ShowWindow(SW_HIDE);

	GetDlgItem (IDOK)->ShowWindow(SW_HIDE);
	GetDlgItem (IDC_BUTTON1)->ShowWindow(SW_HIDE);
	GetDlgItem (IDCANCEL)->ShowWindow(SW_HIDE);
	GetDlgItem (IDC_BTN_REGESITER)->ShowWindow(SW_SHOW);
	CRect rect;
	this->GetWindowRect (rect);
	this->MoveWindow (rect.left ,rect.top ,rect.Width (),rect.Height ()+30,1);

}


void CDlgLogin::OnBnClickedButton2()
{
	GetDlgItem (IDC_STATIC1)->ShowWindow(SW_HIDE);
	GetDlgItem (IDC_STATIC2)->ShowWindow(SW_HIDE);
	GetDlgItem (IDC_STATIC3)->ShowWindow(SW_HIDE);
	GetDlgItem (IDC_STATIC4)->ShowWindow(SW_HIDE);
	GetDlgItem (IDC_STATIC5)->ShowWindow(SW_HIDE);
	GetDlgItem (IDC_STATIC6)->ShowWindow(SW_HIDE);
	GetDlgItem (IDC_STATIC7)->ShowWindow(SW_HIDE);

	GetDlgItem (IDC_TXTNEWUSER)->ShowWindow(SW_HIDE);
	GetDlgItem (IDC_TXTNEWPASSWORD)->ShowWindow(SW_HIDE);
	GetDlgItem (IDC_TXTNEWPASSWORD2)->ShowWindow(SW_HIDE);
	GetDlgItem (IDC_TXTTUIJIANREN)->ShowWindow(SW_HIDE);

	GetDlgItem (IDC_STATIC10)->ShowWindow(SW_SHOW);
	GetDlgItem (IDC_STATIC8)->ShowWindow(SW_SHOW);
	GetDlgItem (IDC_STATIC9)->ShowWindow(SW_SHOW);

	GetDlgItem (IDC_TXTPASSWORD)->ShowWindow(SW_SHOW);
	GetDlgItem (IDC_TXTUSERNAME)->ShowWindow(SW_SHOW);
	GetDlgItem (IDOK)->ShowWindow(SW_SHOW);
	GetDlgItem (IDC_BUTTON2)->ShowWindow(SW_HIDE);
	GetDlgItem (IDC_BUTTON1)->ShowWindow(SW_SHOW);GetDlgItem (IDCANCEL)->ShowWindow(SW_SHOW);
	GetDlgItem (IDC_BTN_REGESITER)->ShowWindow(SW_HIDE);
	CRect rect;
	this->GetWindowRect (rect);
	this->MoveWindow (rect.left ,rect.top ,rect.Width (),rect.Height ()-30,1);
}


BOOL CDlgLogin::OnInitDialog()
{
	CDialog::OnInitDialog();
	CRect rect;
	this->GetWindowRect (rect);
	this->MoveWindow (rect.left ,rect.top ,rect.Width (),rect.Height ()-30,1);

	return TRUE;  // return TRUE unless you set the focus to a control
	// �쳣: OCX ����ҳӦ���� FALSE
}
