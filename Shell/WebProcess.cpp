#include "StdAfx.h"
#include "WebProcess.h"


CWebProcess::CWebProcess(void)
{
}


CWebProcess::~CWebProcess(void)
{
}

bool CWebProcess::Login(CString userName,CString password,CString& responseInfo)
{
	CString str;  
	CString result;CString info;
	try  
	{  
		CInternetSession Session ;   
		CHttpConnection *pHttpConnect = Session.GetHttpConnection(_T("haishengtang.52.xindns4.info")) ;  
		if( pHttpConnect )  
		{  
			CHttpFile* pFile = pHttpConnect->OpenRequest( CHttpConnection::HTTP_VERB_POST ,   
				_T("/Default.aspx"),  
				NULL,  
				1,  
				NULL,  
				NULL,  
				INTERNET_FLAG_NO_COOKIES );  

			CString szFormData = _T("__VIEWSTATE=%2FwEPDwUKLTg0OTIzODQwNWRk9KnDo5um25qx36ySW0lncMJlkTA%3D&__EVENTVALIDATION=%2FwEWBALJpbCEAQKl1bK4CQK1qbSRCwLo4b6%2BDOrFJ0nLwR1lzsbMeEZ0YjDb2pmn&txtUsername="+userName+"&txtPassword="+password+"&BTsubmit=%E7%99%BB%E5%BD%95");  
			if (pFile)  
			{     
				pFile->AddRequestHeaders(_T("POST /Default.aspx HTTP/1.1"));  
				pFile->AddRequestHeaders(_T("Pragma: no-cache"));  
				pFile->AddRequestHeaders(_T("Accept: text/html, application/xhtml+xml, */*"));  
				pFile->AddRequestHeaders(_T("Accept-Encoding: gzip, deflate")); 
				pFile->AddRequestHeaders(_T("Accept-Language: zh-CN"));  
				pFile->AddRequestHeaders(_T("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)"));  
				pFile->AddRequestHeaders(_T("Cookie: jifenqq=164981897; ASP.NET_SessionId=obf55l55ejlsr245ct4h0d45"));   
				pFile->AddRequestHeaders(_T("Content-Type: application/x-www-form-urlencoded"));  
				pFile->AddRequestHeaders(_T("Referer: http://haishengtang.52.xindns4.info/Default.aspx"));  
				pFile->AddRequestHeaders(_T("Connection:   Keep-Alive"));  
				pFile->AddRequestHeaders(_T("Host: haishengtang.52.xindns4.info"));  		
				//   pFile->AddRequestHeaders(szFormData);  

				pFile->SendRequestEx (szFormData.GetLength ());
				pFile->WriteString(szFormData);              
				pFile->EndRequest ();
				// 返回的HTML  
				CString s ;  
				while (pFile->ReadString(s))  
					str += s ;  

				CString temp,m_strCookies; 
				DWORD index=0; 
				while(pFile->QueryInfo(HTTP_QUERY_SET_COOKIE,temp,&index))
				{     
					m_strCookies=m_strCookies+temp;     
				} 
				pFile->Close();  
				delete pFile ;  

			}  


			pHttpConnect->Close() ;  
			delete pHttpConnect ;  
		}  
		wchar_t*    pWChar = NULL;  
		DWORD       nLen1;  

		// 将新浪网页UTF-8格式编码转换成Unicode  
		//LPCSTR pcBuffer;
		// strcpy( pcBuffer , str.GetBuffer(0) );//这样试一下
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

		// 查找登录时服务器时返回的信息  
		str.Format(_T("%s"),pChar);  
		result=str.Mid (0,1);
		responseInfo=str.Mid(1);

	}  
	catch( CInternetException *e )  
	{  
		e->Delete();      
	}  
	if(result ==_T("1"))
	{
		return true;
	}
	else if(result==_T("0"))
	{
		return false;
	}
	else	
	{
		responseInfo =_T("网络异常或无法连接服务器,请检查网络并重启软件！");
		return false;
	}
}
