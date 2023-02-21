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
