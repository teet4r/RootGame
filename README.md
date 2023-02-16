# Project: RootGame

</br>

## 1. 개요
GGJ x Zempie에서 주관한 게임 잼에서 제작한 모바일 2D 게임

</br>

## 2. 제작기간 & 참여인원
- 23.02.03 ~ 23.02.05, 3일
- 기획 2명, 아트 1명, 프로그래머 3명, 총 6명

</br>

## 3. 사용언어 & 도구
- C#
- Visual Studio
- Unity 2D(에디터 버전: 2021.3.18f1)

</br>

## 4. 구동 플랫폼
- Android

</br>

## 5. 주요 구현 이슈
<details>
<summary>미니 게임 3종</summary>
<div markdown="1">

- 디펜스 게임: 아군 소환하여 적 팀 진영을 무너뜨리면 승리
- 치킨 게임: 제한된 시간을 가진 순발력 게임으로, 후라이드 그림인 경우에는 왼쪽 버튼, 양념 그림인 경우에는 오른쪽 버튼을 터치하여 점수를 쌓는 형식. 콤보를 통하여 최고 점수 갱신 가능
- 짝 맞추기 게임: 제한된 시간 내에 코카콜라 vs 펩시와 같은 논란의 중심이 되는 그림들의 짝을 맞춰가면서 진행

</div>
</details>

<details>
<summary>디펜스 게임</summary>
<div markdown="1">

- 화면 상에 아군을 배치하면 자동으로 적진을 향해 움직이는 AI 구현
- 적진을 향해 가다가 적군을 만나면 만난 적군을 타겟팅하여 죽을 때까지 그 목표만 공격
- 적군 AI도 동일하게 구성
- 정해진 시간마다 웨이브 진행
- 아군 붕어빵은 총 5개이며, 35원 짜리는 탱커, 나머지는 딜러로 구성

</div>
</details>

<details>
<summary>치킨 게임</summary>
<div markdown="1">

- 큐를 통하여 치킨 랜덤 생성 후 움직이는 모션 구현
- 왼쪽 버튼과 오른쪽 버튼을 이용하여 콤보를 쌓을 수 있음
- 콤보가 쌓일 때마다 화면 중앙에 현재 콤보 상황을 표시, 20 콤보마다 닭 우는 사운드 재생
- 타이머가 존재하여 콤보가 끊겼을 경우 남은 시간 감소, 콤보가 쌓일수록 줄어드는 시간 폭 증가

</div>
</details>

<details>
<summary>짝 맞추기 게임</summary>
<div markdown="1">

- 카드를 클릭하면 뒤집는 모션 구현
- 두 개의 짝이 맞았을 때 카드가 사라지는 모션 구현
- 타이머가 존재하여 남은 시간내에 모두 짝을 맞추지 못할 경우 게임 오버
- 총 3스테이지

</div>
</details>

<details>
<summary>UI</summary>
<div markdown="1">

- 메인화면에서 각 미니 게임별로 최고 기록 표시
- 상단 바는 고정이며, 미니 게임으로 이동 시에도 항상 활성화
- 일시정지 버튼 클릭 시 게임이 정지되며 사운드 조절 가능

</div>
</details>

</br>

## 6. 스크린샷
<details>
<summary>메인화면</summary>
<div markdown="1">

![RootGame Main0](https://user-images.githubusercontent.com/76508241/219263818-5ca3bbf9-7c47-41fc-bd4e-01590016b9a1.jpg)
![RootGame Main1](https://user-images.githubusercontent.com/76508241/219263823-5cf0a94e-0dfa-4686-af58-66a3f6c733ff.jpg)
![RootGame Main2](https://user-images.githubusercontent.com/76508241/219263824-bb7ac709-897f-45e7-a4ba-9f8dd9f1ac10.jpg)
![RootGame Main3](https://user-images.githubusercontent.com/76508241/219263827-4d738c94-8b9c-49c2-a849-86bff113487a.jpg)
- 미니 게임마다 최고 기록 표시

</div>
</details>

<details>
<summary>인게임</summary>
<div markdown="1">

![RootGame Ingame1-0](https://user-images.githubusercontent.com/76508241/219263828-908eeb56-a972-4024-91c4-3575948fb09d.jpg)
![RootGame Ingame1-1](https://user-images.githubusercontent.com/76508241/219263829-ef609d9c-2529-49cc-be48-8918f3c24bec.jpg)
- 붕어빵 버튼을 클릭한 후 화면 속 붉은 영역을 터치하면 해당 위치에 아군을 배치
![RootGame Ingame1-2](https://user-images.githubusercontent.com/76508241/219263840-06afe2aa-f9e5-4517-8ff9-7d13a4126fac.jpg)
![RootGame Ingame2-0](https://user-images.githubusercontent.com/76508241/219265366-30bfe142-d44b-457a-9c59-2e3a643072da.jpg)
![RootGame Ingame2-1](https://user-images.githubusercontent.com/76508241/219265371-7da0e0fd-0c93-4306-9d6d-74c763d1b291.jpg)
![RootGame Ingame3-0](https://user-images.githubusercontent.com/76508241/219263838-246131c8-129a-4e11-b244-446035c04532.jpg)

</div>
</details>

</br>

## 7. 링크
- [GGJ x Zempie 2023 후기](https://velog.io/@dev_cocoa/GGJ-x-Zempie-2023-%ED%9B%84%EA%B8%B0-%EA%B7%BC%EB%B3%B8%EC%9D%84-%EC%B0%BE%EC%95%84%EC%84%9C#ggj-x-zempie)
- [Global Game Jam site](https://globalgamejam.org/2023/games/gameofroot-7)
- [플레이 영상 및 다운로드](https://drive.google.com/drive/folders/18fFOEBF5Y46eXhM7gf_BqANMraGZRw35)
