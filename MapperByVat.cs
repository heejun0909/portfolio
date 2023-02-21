/// <summary title="업무통합형 테이블에서 조회해온 데이터를 부가세업무 형태로 Mappeing 하는 클래스 입니다">
/// 1. Creator      : Shin Heejun
/// 2. Description  : 업무통합형 테이블에서 조회해온 데이터를 부가세업무 형태로 Mappeing 하는 클래스
/// </summary>
public static class MapperByVat
{
    /// <summary>
    /// dataRow를 정해진 구조체로 Mapping하는 역할의 static Public 함수입니다.
    /// </summary>
    /// <typeparam name="TSource">TSource</typeparam>
    /// <param name="context">context</typeparam>
    /// <param name="src">Source</typeparam>
    /// <param name="dest">DestNation</typeparam>
    public static void Mapper<TSource>(Context context, DataRow src, VatDto dest) 
    {
        foreach(KeyValuePair<string, string> item in getMapper(context)) {
            dest.Additional[item.Key] = src[item.Value];
        }
    }

    /// <summary>
    /// 국가별에 따른 구조체를 Return하는 private 함수입니다.
    /// </summary>
    /// <param name="context">context</typeparam>
    private static Dictionary<string, string> getMapper(Context context) {
        if (context.Country == "Taiwan") {
            return StructureVatByTW.VatMap;
        } else if(context.Country == "Vetnam") {
            return StructureVatByVM.VatMap;
        }

        return StructureVatByKR.VatMap;
    }
}

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
