
// ShellDlg.h : 头文件
//

#pragma once
#include "mybutton.h"
#include "explorer1.h"
//#include "ximage.h"
#include "afxwin.h"
#include "WebProcess.h"
#define WM_AUTOLOGIN (WM_USER+1)
// CShellDlg 对话框
class CShellDlg : public CDialogEx
{
// 构造
public:
	CShellDlg(CWnd* pParent = NULL);	// 标准构造函数

// 对话框数据
	enum { IDD = IDD_SHELL_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV 支持
public:
	CImage m_bkImage;
// 实现
protected:
	HICON m_hIcon;

	// 生成的消息映射函数
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()

	//CxImage *m_lpImage;
	////GIF图片帧数
	//int num;

	//是否在主界面
	//bool m_isMainFrom;


public:
	afx_msg BOOL OnEraseBkgnd(CDC* pDC);
	CMyButton m_btnMain;
	CMyButton m_btnMenu2;
	CMyButton m_btnMenu3;
	CMyButton btnMenu4;
	CMyButton m_btnMenu5;
	CExplorer1 m_WebMain;
	CMyButton m_btnMenu6;

	CString m_QQ;
	CString m_myPassword;
	CMyButton m_btnMenu7;
	CMyButton m_btnMenu9;
	CMyButton m_btnMenu8;
	CExplorer1 m_Guanggao;
	afx_msg void OnBnClickedBtnMain2();
	afx_msg void OnBnClickedBtnMain3();
	afx_msg void OnBnClickedBtnMain4();
	afx_msg void OnBnClickedBtnMain5();
	afx_msg void OnBnClickedBtnMain();
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	afx_msg BOOL OnSetCursor(CWnd* pWnd, UINT nHitTest, UINT message);
	afx_msg void OnTimer(UINT_PTR nIDEvent);
protected:

	afx_msg LRESULT OnAutoLogin(WPARAM wParam,LPARAM lParam);
public:
		CStatic m_picJia;
	afx_msg void OnStnClickedPicjia();
	CExplorer1 m_webHead;
	afx_msg void OnBnClickedBtnMain9();
	afx_msg void OnBnClickedBtnMain8();
	afx_msg void OnBnClickedBtnMain6();
	afx_msg void OnBnClickedBtnMain7();
	DECLARE_EVENTSINK_MAP()
	void DocumentCompleteExplorer2(LPDISPATCH pDisp, VARIANT* URL);
	void DocumentCompleteExplorer1(LPDISPATCH pDisp, VARIANT* URL);
};
