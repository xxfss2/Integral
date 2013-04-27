#pragma once
#include <afxinet.h>  
#include <afx.h>
class CWebProcess
{
public:
	CWebProcess(void);
	~CWebProcess(void);

	bool Login(CString userName,CString password,CString& responseInfo);
};

