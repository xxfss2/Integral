#pragma once
#include "WebProcess.h"

// CDlgLogin �Ի���

class CDlgLogin : public CDialog
{
	DECLARE_DYNAMIC(CDlgLogin)

public:
	CDlgLogin(CWnd* pParent = NULL);   // ��׼���캯��
	virtual ~CDlgLogin();

// �Ի�������
	enum { IDD = IDD_DLG_LOGIN };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

	DECLARE_MESSAGE_MAP()

	bool GetMacByCmd( CString &strMac );
public:
	afx_msg void OnBnClickedOk();
	afx_msg void OnBnClickedBtnRegesiter();
	afx_msg void OnBnClickedButton1();
	afx_msg void OnBnClickedButton2();
	virtual BOOL OnInitDialog();

	CString m_QQ;
	CString m_password;
};
