using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    //Dictionary<int, Sprite> PorData;
    Dictionary<int, Sprite> myPorData;

    public Sprite[] porArr;
    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        //PorData = new Dictionary<int, Sprite>();
        myPorData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000,new string[] { "여보세요?:100:0:0:0", "안녕! 오랜만이야~ 요즘 잘지내?:2:0:0", "아 너였구나 나야 평소처럼 잘지내고 있지:107:0:0", "근데 무슨일로 연락했어?:100:0:0" , "다름이 아니라..우리 얼굴 본지 좀 됬잖아:0:0:0" , "그래서 오랜만에 만나서 밥이나 한 번 먹을까해서 말이야~:1:0:0" , "나도 오랜만에 얼굴 보면 좋지:107:0:0", "언제 만날까? :107:0:0" , "1시간 30분후 세모세모역에서 만나는건 어때?:0:0:0" , "오늘 남은 일정도 없고:101:0:0","세모세모역 주변에는 맛집도 많으니 괜찮네:107:0:0" , "그럼 그때보자~:2:0:0" , "흠...:100:0:0","여유롭게 가려면 지금 바로 출발해야 할것 같네:101:4:0" });
        talkData.Add(2000, new string[] { "엘리베이터 금방 왔네:100:0:0" ,"저기요:0:0:0", "예?:101:0:0", "지금 꼭 타야 돼요?:1:0:0", "예..? 그게 무슨 말씀이시죠?:102:0:0", "그러니까 당신이랑 같이타면 좁아지니까 다음에 타면 안되냐고요:0:0:0" , "예? 그게 무슨...충분히 같이 탈 수 있는데...:102:0:0", "내가 일부로 그러는게 아니라 좁아져서 그렇다니까요?:1:0:0" , "헛소리 그만하시고 빨리 비켜주세요:104:0:0" , "하.. 왜 몸도 불편하면서 집에 있지 않고 나와서....:2:0:0", "그런소리 하실거면 빨리 비키시라구요!:103:0:0", "하..:2:1:0" });

        talkData.Add(1100, new string[] { "잠깐 세모세모역이면..:100:0:0", "네모네모역에서 6호선을 타고 가서\n별별역에서 3호선으로 환승해야하는데...:101:0:0", "아.. 별별역에서 환승하려면 엘리베이터만\n 4번을 타야하잖아?:105:0:0", "일찍 나온게 정답이였네:106:0:0" });
        talkData.Add(1110, new string[] { "하.. 다시 생각해도 화나네..:103:0:0" , "사람이 많았던것도 아니고 혼자였으면서:104:0:0" , "좁으니까 다음에 타라는 것도 모자라 \n몸이 불편하면 집에나 있으라고?:103:0:0" , "어이가 없어서:104:0:0" });
        talkData.Add(1120, new string[] { "...?:100:0:0" , "엘리베이터가 어디있지?:102:0:0" });
        talkData.Add(1130, new string[] { "저 앞쪽이 네모네모역 1번 출구인가 :100:0:0" , "계단에 리프트는 없어보이네..:101:0:0" , "저 뒤쪽에 엘레베이터가 있는것 같으니 저걸 타면 되겠다:100:0:0" });
        talkData.Add(100, new string[] { "이봐 제정신이야?:104:0:0", "휠체어를 타고 리프트도 없는 계단이라니:103:0:0" , "나를 죽이고 싶은거야?:104:0:0" , "그런 선택을 내가 따라 줄리가 없잖아:103:0:0" });
        talkData.Add(101, new string[] { "다시 선택해도 계단으로는 안갈거야:101:0:0" });
        talkData.Add(300, new string[] { "여기로 들어가야...:101:0:0", "아..:105:0:0", "휠체어 때문에 못들어가네...:106:0:0" });
        talkData.Add(400, new string[] { "휠체어는 이쪽으로 들어가야 될것 같네:101:1:0" });
        talkData.Add(501, new string[] { "또 나를 계단으로 보내려 하네:106:0:0", "내가 진짜 죽길 바라는거야?:102:0:0", "아니면 진심으로 내가 휠체어를 타고 계단을\n내려갈 수 있을거라 생각하는거야?:102:0:0" , "후자라면 아쉽게도 나에게 그런 재주는 없어:106:0:0" });
        talkData.Add(500, new string[] { "휠체어를 타고 리프트 없는 계단을 갈 수 있을것 같아?:104:0:0" , "내가 이런 선택을 따를거라고 생각한건 아니겠지?:103:0:0" });
        talkData.Add(600, new string[] { "엘리베이터를 누가 이렇게 안쪽에다가 만들어 놓은거야..:105:0:0", "찾기도 힘들게..:106:0:0", "솔직히 계단보다 먼저 찾을 수 있어야하는거 아니야?:102:1:0" });
        talkData.Add(700, new string[] { "드디어 왔네:101:0:2", "어서 들어가야지:100:0:0", "아... :105:0:0","망했다..:106:0:0", "앞바퀴 꼈다...:106:1:3" });

        // talkData.Add(,new string[]{":100:0:0"});



        //PorData.Add(1000 + 0, porArr[0]);
        myPorData.Add(0 + 0, porArr[0]);
        myPorData.Add(0 + 1, porArr[1]);
        myPorData.Add(0 + 2, porArr[2]);
        myPorData.Add(0 + 3, porArr[3]);
        myPorData.Add(0 + 4, porArr[4]);
        myPorData.Add(0 + 5, porArr[5]);
        myPorData.Add(0 + 6, porArr[6]);
        myPorData.Add(0 + 7, porArr[7]);

        myPorData.Add(1000 + 0, porArr[8]);
        myPorData.Add(1000 + 1, porArr[9]);
        myPorData.Add(1000 + 2, porArr[10]);

        myPorData.Add(2000 + 0, porArr[11]);
        myPorData.Add(2000 + 1, porArr[12]);
        myPorData.Add(2000 + 2, porArr[13]);


    }

    public string GetTalk(int id,int talkIndex)
    {
        if(talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPor(int id, int porIndex)
    {
        return myPorData[id + porIndex];
    }
}
