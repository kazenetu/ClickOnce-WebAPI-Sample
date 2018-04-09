# ClickOnce-WebAPI-Sample
ClickOnceとWebAPIの連携サンプル

# 環境
* Visual Studio 2015以上
* Windows7以上

# 実行手順

## 方法1：ClickOnceでクライアントアプリケーションをインストール
※Visual Studioを二つ立ち上げると楽に作業ができます。

### 1.クライアントアプリケーションの発行
1. ClickOnceTest.slnを開く
1. プロジェクトのプロパティを開く
1. プロパティの左メニューから「署名」を選択   
  「テスト証明書の作成」ボタンをクリック  
  パスワードを入力してテスト証明書を作成する
1. プロパティの左メニューから「公開」を選択   
  「今すぐ発行」ボタンをクリック
1. 「ルートフォルダ\WebAPI\publish」にClickOnceダウンロードページが作成される

### 2.WebAPIサーバのデバッグ実行
1. WebAPI.slnを開く
1. F5などでデバッグ実行する

### 3.動作確認
1. IEなどで「http://localhost:8080/publish/」にアクセスする
1. ClickOnceダウンロードページが表示されるので「インストールボタン」をクリックする
1. Windowsアプリが実行される
1. Windowsアプリの「サーバー問い合わせ」ボタンをクリックする
   ※WebAPIのTestController#Get()が実行される

## 方法2：クライアントアプリケーションをデバッグ実行
※Visual Studioを二つ立ち上げます

### 1.WebAPIサーバのデバッグ実行
1. WebAPI.slnを開く
1. F5などでデバッグ実行する

### 2.クライアントアプリケーションのデバッグ実行
1. ClickOnceTest.slnを開く
1. プロジェクトのプロパティを開く
1. プロパティの左メニューから「デバッグ」を選択   
1. 「コマンドライン引数」に「http://localhost:8080/」を設定
1. F5などでデバッグ実行する  
   ※「現在のプロジェクト設定は、プロジェクトが特定のセキュリティのアクセス許可でデバッグされることを指定しています。このモードでは、コマンドライン引数は実行可能ファイルには渡されません。デバッグを続行しますか？」とダイアログが表示される。  
   「はい」をクリックする。
  
### 3.動作確認
1. Windowsアプリの「サーバー問い合わせ」ボタンをクリックする
   ※WebAPIのTestController#Get()が実行される
