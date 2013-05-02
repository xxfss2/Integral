
// ShellDlg.cpp : 实现文件
//

#include "stdafx.h"
#include "Shell.h"
#include "ShellDlg.h"
#include "afxdialogex.h"
#include "DlgLogin.h"
#include "Mshtml.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CShellDlg 对话框




CShellDlg::CShellDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CShellDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDI_ICON16);
}

void CShellDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_BTN_MAIN, m_btnMain);
	DDX_Control(pDX, IDC_BTN_MAIN2, m_btnMenu2);
	DDX_Control(pDX, IDC_BTN_MAIN3, m_btnMenu3);
	DDX_Control(pDX, IDC_BTN_MAIN4, btnMenu4);
	DDX_Control(pDX, IDC_BTN_MAIN5, m_btnMenu5);
	DDX_Control(pDX, IDC_EXPLORER1, m_WebMain);
	DDX_Control(pDX, IDC_BTN_MAIN6, m_btnMenu6);
	DDX_Control(pDX, IDC_BTN_MAIN7, m_btnMenu7);
	DDX_Control(pDX, IDC_BTN_MAIN9, m_btnMenu9);
	DDX_Control(pDX, IDC_BTN_MAIN8, m_btnMenu8);
	DDX_Control(pDX, IDC_WEB_GUANGGAO, m_Guanggao);
	DDX_Control(pDX, IDC_PICJIA, m_picJia);
	DDX_Control(pDX, IDC_EXPLORER2, m_webHead);
}

BEGIN_MESSAGE_MAP(CShellDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_WM_ERASEBKGND()
	ON_BN_CLICKED(IDC_BTN_MAIN2, &CShellDlg::OnBnClickedBtnMain2)
	ON_BN_CLICKED(IDC_BTN_MAIN3, &CShellDlg::OnBnClickedBtnMain3)
	ON_BN_CLICKED(IDC_BTN_MAIN4, &CShellDlg::OnBnClickedBtnMain4)
	ON_BN_CLICKED(IDC_BTN_MAIN5, &CShellDlg::OnBnClickedBtnMain5)
	ON_BN_CLICKED(IDC_BTN_MAIN, &CShellDlg::OnBnClickedBtnMain)
	ON_WM_SETCURSOR()
	ON_WM_TIMER()
	ON_STN_CLICKED(IDC_PICJIA, &CShellDlg::OnStnClickedPicjia)
	ON_BN_CLICKED(IDC_BTN_MAIN9, &CShellDlg::OnBnClickedBtnMain9)
	ON_BN_CLICKED(IDC_BTN_MAIN8, &CShellDlg::OnBnClickedBtnMain8)
	ON_BN_CLICKED(IDC_BTN_MAIN6, &CShellDlg::OnBnClickedBtnMain6)
	ON_BN_CLICKED(IDC_BTN_MAIN7, &CShellDlg::OnBnClickedBtnMain7)
	ON_MESSAGE(WM_AUTOLOGIN,&CShellDlg::OnAutoLogin)
END_MESSAGE_MAP()


// CShellDlg 消息处理程序
UINT AsynSendData(LPVOID pParam)
{
	CShellDlg  *pDlg=(CShellDlg*)AfxGetApp ()->GetMainWnd();

	pDlg->m_webHead .Navigate ("http://pc.11343777.com/UserMain.aspx?idd="+pDlg->m_QQ,NULL,NULL,NULL,NULL);
	pDlg->m_Guanggao.Navigate ("http://soft.11343777.com/soft/ad.html",NULL,NULL,NULL,NULL); 
	pDlg->m_WebMain.Navigate ("http://pc.11343777.com/Video/UnLoginVideo.aspx",NULL,NULL,NULL,NULL); 

	CStdioFile file;
	CString path="D:\\千术大揭密.dat";
	
	if(file.Open (path,CStdioFile::modeRead))
	{
		::Sleep (2000);
		CString userName,password;
		file.ReadString (userName );
		file.ReadString (password);
		CWebProcess web;
		CString info;
		bool result=web.Login (userName,password,info);
		if(result)
		{
			pDlg->m_QQ =userName ;
			pDlg->m_myPassword =password ;
			pDlg->m_webHead .Navigate ("http://pc.11343777.com/UserMain.aspx?idd="+pDlg->m_QQ,NULL,NULL,NULL,NULL);
			pDlg->m_WebMain .Navigate ("http://pc.11343777.com/Video/Main.aspx?idd="+pDlg->m_QQ+"&pw="+pDlg->m_myPassword,NULL,NULL,NULL,NULL);
			pDlg->m_picJia.ShowWindow (SW_HIDE);
		}
		else
		{
			pDlg->MessageBox (info);

		}

	}
	return 1;
}
BOOL CShellDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// 设置此对话框的图标。当应用程序主窗口不是对话框时，框架将自动
	//  执行此操作
	SetIcon(m_hIcon, TRUE);			// 设置大图标
	SetIcon(m_hIcon, FALSE);		// 设置小图标

	m_bkImage.LoadFromResource(AfxGetInstanceHandle(),IDB_TOPBACK3);
		CRect rect;
	this->GetWindowRect (rect);
	this->MoveWindow (rect.left ,rect.top ,980,725);
	CenterWindow( GetDesktopWindow() );

	m_Guanggao.MoveWindow(0,575,974,140);
	m_webHead .MoveWindow (0,100,974,50);
	m_WebMain.MoveWindow (0,150,974,425);
	m_picJia.MoveWindow(140,205,400,334);
	//m_webHead .Navigate ("http://pc.11343777.com/UserMain.aspx?idd="+m_QQ,NULL,NULL,NULL,NULL);
	//m_Guanggao.Navigate ("http://soft.11343777.com/soft/ad.html",NULL,NULL,NULL,NULL); 
	//m_WebMain.Navigate ("http://pc.11343777.com/Video/UnLoginVideo.aspx",NULL,NULL,NULL,NULL); 
	//PostMessage(WM_AUTOLOGIN);
	::AfxBeginThread (AsynSendData,NULL);
	return TRUE;  // 除非将焦点设置到控件，否则返回 TRUE
}




LRESULT CShellDlg::OnAutoLogin(WPARAM wParam,LPARAM lParam)
{
	CStdioFile file;
	CString path="D:\\千术大揭密.dat";
	
	if(file.Open (path,CStdioFile::modeRead))
	{
		//::Sleep (2000);
		CString userName,password;
		file.ReadString (userName );
		file.ReadString (password);
		CWebProcess web;
		CString info;
		bool result=web.Login (userName,password,info);
		if(result)
		{
			this->m_QQ =userName ;
			this->m_myPassword =password ;
			m_webHead .Navigate ("http://pc.11343777.com/UserMain.aspx?idd="+m_QQ,NULL,NULL,NULL,NULL);
			m_WebMain .Navigate ("http://pc.11343777.com/Video/Main.aspx?idd="+m_QQ+"&pw="+m_myPassword,NULL,NULL,NULL,NULL);
			m_picJia.ShowWindow (SW_HIDE);
		}
		else
		{
			MessageBox (info);

		}

	}
	return 1;
}
// 如果向对话框添加最小化按钮，则需要下面的代码
//  来绘制该图标。对于使用文档/视图模型的 MFC 应用程序，
//  这将由框架自动完成。

void CShellDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 用于绘制的设备上下文

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// 使图标在工作区矩形中居中
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// 绘制图标
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

//当用户拖动最小化窗口时系统调用此函数取得光标
//显示。
HCURSOR CShellDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



BOOL CShellDlg::OnEraseBkgnd(CDC* pDC)
{
	CRect rc;
	GetClientRect(&rc);
	m_bkImage.BitBlt(pDC->GetSafeHdc(),rc,CPoint(0,0),SRCCOPY);
  
	//pDC->FillSolidRect(&rc ,  RGB(236,233,216)  );   


	return TRUE;
	//return CDialogEx::OnEraseBkgnd(pDC);
}


void CShellDlg::OnBnClickedBtnMain2()
{
		m_picJia .ShowWindow (SW_HIDE);
		
		m_WebMain.MoveWindow (0,100,974,475,1);
		m_WebMain .Navigate ("http://pc.11343777.com/Page/TuiguangsQQ.aspx?idd="+m_QQ,NULL,NULL,NULL,NULL);
	
		//m_webHead.ShowWindow (SW_HIDE);
}


void CShellDlg::OnBnClickedBtnMain3()
{
	m_picJia .ShowWindow (SW_HIDE);
	//m_webHead.ShowWindow (SW_HIDE);
	m_WebMain.MoveWindow (0,100,974,475,1);
	// TODO: 在此添加控件通知处理程序代码
	m_WebMain .Navigate ("http://pc.11343777.com/Page/TuiguangShouyi.aspx?idd="+m_QQ,NULL,NULL,NULL,NULL);
}


void CShellDlg::OnBnClickedBtnMain4()
{
		m_picJia .ShowWindow (SW_HIDE);
	// TODO: 在此添加控件通知处理程序代码
		m_WebMain.MoveWindow (0,100,974,625,1);
//	m_webHead.ShowWindow (SW_HIDE);
		m_WebMain .Navigate ("http://pc.11343777.com/Page/Chongzhi.aspx?idd="+m_QQ,NULL,NULL,NULL,NULL);
}


void CShellDlg::OnBnClickedBtnMain5()
{
//	m_webHead.ShowWindow (SW_HIDE);
	m_picJia .ShowWindow (SW_HIDE);
	m_WebMain.MoveWindow (0,100,974,475,1);
	m_WebMain .Navigate ("http://pc.11343777.com/Page/CashKa.aspx?idd="+m_QQ,NULL,NULL,NULL,NULL);
}


void CShellDlg::OnBnClickedBtnMain()
{
	m_webHead.ShowWindow (SW_SHOW);
	m_picJia .ShowWindow (SW_HIDE);
	m_WebMain.MoveWindow (0,150,974,425,1);

	if(m_QQ .GetLength ()>0 && m_myPassword.GetLength ()>0)
	{
		m_WebMain .Navigate ("http://pc.11343777.com/Video//Main.aspx?idd="+m_QQ+"&pw="+m_myPassword,NULL,NULL,NULL,NULL);
	}
	else
	{
		m_WebMain.Navigate ("http://pc.11343777.com/Video/UnLoginVideo.aspx",NULL,NULL,NULL,NULL); 
		m_picJia .ShowWindow (SW_SHOW);
	}
	m_webHead .MoveWindow (0,100,974,50,1);
}


BOOL CShellDlg::PreCreateWindow(CREATESTRUCT& cs)
{
	//if( !CFrameWnd::PreCreateWindow(cs) ) 
  //      return FALSE; 
    // TODO: 在此处通过修改 
    //  CREATESTRUCT cs 来修改窗口类或样式 
    cs.cx = 630; 
    cs.cy = 560; 
    cs.style &= ~WS_MAXIMIZEBOX;//禁止最大化 
    cs.style &= ~WS_THICKFRAME;//禁止调整大小 
    //cs.style &= ~WS_MINIMIZEBOX;禁止最小化 
    cs.lpszName = "算法收集器"; 
    return TRUE; 


	return CDialogEx::PreCreateWindow(cs);
}


BOOL CShellDlg::OnSetCursor(CWnd* pWnd, UINT nHitTest, UINT message)
{
	switch(pWnd-> GetDlgCtrlID()) 
	{ 
	case   IDC_BTN_MAIN: 
	case   IDC_BTN_MAIN2:
	case   IDC_BTN_MAIN3: 
	case   IDC_BTN_MAIN4: 
	case   IDC_BTN_MAIN5: 
	case   IDC_BTN_MAIN6: 
	case   IDC_BTN_MAIN7: 
	case   IDC_BTN_MAIN8:case   IDC_BTN_MAIN9:
		SetCursor(::LoadCursor(NULL,   IDC_HAND)); 
		break; 
	default   : 
		SetCursor(::LoadCursor(NULL,   IDC_ARROW)); 
	} 



	return true;
}


void CShellDlg::OnTimer(UINT_PTR nIDEvent)
{

}


void CShellDlg::OnStnClickedPicjia()
{
	if(m_QQ .GetLength ()==0  || m_myPassword.GetLength ()==0)
	{
		CDlgLogin dlgLogin;
		INT_PTR nLoginRes=dlgLogin.DoModal ();
		if(nLoginRes==IDOK)
		{
			this->m_QQ =dlgLogin.m_QQ ;
			this->m_myPassword =dlgLogin.m_password ;
			m_webHead .Navigate ("http://pc.11343777.com/UserMain.aspx?idd="+m_QQ,NULL,NULL,NULL,NULL);
			m_WebMain .Navigate ("http://pc.11343777.com/Video/Main.aspx?idd="+m_QQ+"&pw="+m_myPassword,NULL,NULL,NULL,NULL);
			m_picJia .ShowWindow (SW_HIDE);
		}
	}
}


void CShellDlg::OnBnClickedBtnMain9()
{
	m_picJia .ShowWindow (SW_HIDE);
	m_WebMain.MoveWindow (0,100,974,475,1);
	m_WebMain .Navigate ("http://soft.11343777.com/soft/about.html",NULL,NULL,NULL,NULL);
}


void CShellDlg::OnBnClickedBtnMain8()
{
	m_picJia .ShowWindow (SW_HIDE);
	m_WebMain.MoveWindow (0,100,974,475,1);
	m_WebMain .Navigate ("http://soft.11343777.com/soft/daili.html",NULL,NULL,NULL,NULL);
}


void CShellDlg::OnBnClickedBtnMain6()
{
	m_picJia .ShowWindow (SW_HIDE);
	m_WebMain.MoveWindow (0,100,974,475,1);
	m_WebMain .Navigate ("http://soft.11343777.com/soft/ad.html",NULL,NULL,NULL,NULL);
}


void CShellDlg::OnBnClickedBtnMain7()
{
	m_picJia .ShowWindow (SW_HIDE);
	m_WebMain.MoveWindow (0,100,974,475,1);
	m_WebMain .Navigate ("http://soft.11343777.com/soft/product.html",NULL,NULL,NULL,NULL);
}
BEGIN_EVENTSINK_MAP(CShellDlg, CDialogEx)
	ON_EVENT(CShellDlg, IDC_EXPLORER2, 259, CShellDlg::DocumentCompleteExplorer2, VTS_DISPATCH VTS_PVARIANT)
	ON_EVENT(CShellDlg, IDC_EXPLORER1, 259, CShellDlg::DocumentCompleteExplorer1, VTS_DISPATCH VTS_PVARIANT)
END_EVENTSINK_MAP()


void CShellDlg::DocumentCompleteExplorer2(LPDISPATCH pDisp3, VARIANT* URL)
{
	HRESULT hr;
	IDispatch *pDisp2 = m_webHead .get_Document ();

	IHTMLDocument2 *pDocument = NULL;
	IHTMLElement*   pEl;  
	IHTMLBodyElement   *   pBodyEl;  
	hr = pDisp2->QueryInterface(IID_IHTMLDocument2, (void**)&pDocument);
	if(SUCCEEDED(pDocument->get_body(&pEl)))  
	{  
		if(SUCCEEDED(pEl->QueryInterface(IID_IHTMLBodyElement,   (void**)&pBodyEl)))  
		{  
			pBodyEl->put_scroll(L"no");//去滚动条
		}  
		IHTMLStyle   *phtmlStyle;  
		pEl->get_style(&phtmlStyle);  

	} 



}


void CShellDlg::DocumentCompleteExplorer1(LPDISPATCH pDisp, VARIANT* URL)
{

}
