Feature: ProfileDao
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: 依據使用者帳號查詢密碼
	Given 使用者帳是 "TestUser"
	And 預計Users資料應有
	| UserName | DisplayName | Enable | Email           | Password | Creator |
	| TestUser | TestUser    | true   | TestUser@com.tw | abcde    | 0       |
	When 呼叫GetPassword方法
	Then 查詢結果應為 "abcde"

Scenario: 依據使用者帳號查詢密碼,帳號不存在
	Given 使用者帳是 "TestUser"
	When 呼叫GetPassword方法
	Then 查詢結果應為 ""
