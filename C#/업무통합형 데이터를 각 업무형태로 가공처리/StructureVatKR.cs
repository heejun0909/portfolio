/// <summary>
/// 한국 부가세 형태의 구조체 입니다.
/// </summary>
public static class StructureVatKR
{
    get {
        return new Dictionary<string, string>() {
            //KR
            { TAX_NO,   "TXT01"},    //세금계산서 일련번호
            { CARD_NO,  "TXT02"},    //카드번호
            { SETTLE,   "TXT03"},    //청구영수
            { IN_TYPE,  "TXT04"},    //예정누락분
            { ECTAX_GB, "TXT05"},    //기한후 전송
            { ECTAX_FLAG, "TXT06"},  //인보이스 종류
            { SETTLE_AMT1, "NUM01"}, //현금
            { SETTLE_AMT2, "NUM02"}, //수표
            { SETTLE_AMT3, "NUM03"}, //어음
            { SETTLE_AMT4, "NUM04"}  //외상매출금
        }

    }
}
