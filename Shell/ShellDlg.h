
// ShellDlg.h : ͷ�ļ�
//

#pragma once
#include "mybutton.h"
#include "explorer1.h"
//#include "ximage.h"
#include "afxwin.h"
#include "WebProcess.h"
#define WM_AUTOLOGIN (WM_USER+1)
// CShellDlg �Ի���
class CShellDlg : public CDialogEx
{
// ����
public:
	CShellDlg(CWnd* pParent = NULL);	// ��׼���캯��

// �Ի�������
	enum { IDD = IDD_SHELL_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV ֧��
public:
	CImage m_bkImage;
// ʵ��
protected:
	HICON m_hIcon;

	// ���ɵ���Ϣӳ�亯��
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()

	//CxImage *m_lpImage;
	////GIFͼƬ֡��
	//int num;

	//�Ƿ���������
	//bool m_isMainFrom;

	CWinThread* pThread;

public:
	afx_msg BOOL OnEraseBkgnd(CDC* pDC);
	CMyButton m_btnMain;
	CMyButton m_btnMenu2;
	CMyButton m_btnMenu3;
	CMyButton btnMenu4;
	CMyButton m_btnMenu5;
	CExplorer1 m_WebMain;
	CMyButton m_btnMenu6;
		bool m_isShowJia;
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
	//CExplorer1 m_webHead;
	afx_msg void OnBnClickedBtnMain9();
	afx_msg void OnBnClickedBtnMain8();
	afx_msg void OnBnClickedBtnMain6();
	afx_msg void OnBnClickedBtnMain7();
	DECLARE_EVENTSINK_MAP()
	void DocumentCompleteExplorer2(LPDISPATCH pDisp, VARIANT* URL);
	void DocumentCompleteExplorer1(LPDISPATCH pDisp, VARIANT* URL);
};
