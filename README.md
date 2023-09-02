# Comment Translator for Visual Studio 2022

[![Build status](https://dev.azure.com/netcorevip/BuildsGit/_apis/build/status/comment-translator-china-CI)](https://dev.azure.com/netcorevip/BuildsGit/_build/latest?definitionId=9)[![Build status](https://ci.appveyor.com/api/projects/status/j2dx6u8lpwwi75gn?svg=true)](https://ci.appveyor.com/project/corevip/comment-translator-china)

아래 참조로 한글로 수정
[marketplace](https://marketplace.visualstudio.com/items?itemName=Hikari.CommentTranslator64)
[Comment Translator](https://marketplace.visualstudio.com/items?itemName=NguynThunTan.CommentTranslator)

최초의 제작자 
[comment-translator-china](https://github.com/netcorevip/comment-translator-china)

지원되는 버전：Visual Studio 2022


### 초기화 설치

[![设置](Images/Options.png)


## 기능

#### 수동번역

텍스트를 선택하고 마우스 오른쪽 버튼 클릭 번역 메뉴 또는 단축키 Alt+Z를 통해 번역합니다.
텍스트를 선택하지 않은 경우 자동으로 줄 선택
한 번의 클릭으로 번역된 텍스트 복사
![수동 번역](Images/Auto-Selecte-Line.gif)



#### 자동번

- 열려 있는 파일의 주석을 자동으로 번역합니다.

##### 지원 언어 파일

- CSharp
- C/C++
- FSharp
- Visual Basic
- Html
- CSS
- JavaScript/TypeScript
- Xml
- Xaml
- Python
- Razor

##### 열린 파일의 자동 번역 켜기/끄기

마우스 오른쪽 버튼을 클릭하여 자동 번역 또는 단축키 ALT+Shift+Z를 켜거나 끕니다.
도구->옵션->댓글 번역기 한->설정/해제

![SetAuto](Images/SetAuto.gif)



#### 열린 파일의 자동 번역

> 파일이 열렸습니다. 파일을 닫았다가 다시 열면 적용됩니다.

![메모 자동 번역](Images/Auto-File-translate.gif)




출처: [Comment Translator](<https://marketplace.visualstudio.com/items?itemName=NguynThunTan.CommentTranslator>)



## 기여

이 프로젝트에 기여하고 싶다면 [가이드라인](CONTRIBUTING.md)。을 참고해주세요.

## License

[Apache 2.0](LICENSE.txt)

현재 Newtonsoft.Json 13.0.x 버전을 인용할 경우 vsixmanifest 파일에 Asset Type="Microsoft.VisualStudio.Assembly"를 추가해야 하는데, 12.0.x를 인용할 때는 그렇지 않습니다. 아직은 이유를 모르겠습니다.
