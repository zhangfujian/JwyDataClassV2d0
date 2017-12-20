using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace JwyDataClassV2d0
{
    [Serializable]
    [XmlRoot("经纬仪小球测风")]
    public class JwyObserveDataV2d0
    {
        #region 公开方法定义
        /// <summary>
        /// 读取空中风观测记录表，得到经纬仪观测数据类
        /// </summary>
        /// <param name="fileName">记录表文件的文件名</param>
        /// <returns>经纬仪观测数据对象，如果文件异常则返回null</returns>
        public static JwyObserveDataV2d0 ReadJlbFile(string fileName)
        {
            JwyObserveDataV2d0 resultJwyObservefData = null;
            try
            {
                if (File.Exists(fileName))
                {
                    StreamReader sR = new StreamReader(fileName);
                    XmlSerializer xmlS = new XmlSerializer(typeof(JwyObserveDataV2d0));
                    resultJwyObservefData = (JwyObserveDataV2d0)xmlS.Deserialize(sR);
                    sR.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
            return resultJwyObservefData;
        }
        public static void SaveToJlbFile(JwyObserveDataV2d0 jwyObserveData,string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(JwyObserveDataV2d0));
            StreamWriter sW = new StreamWriter(fileName);
            try
            {
                xmlSerializer.Serialize(sW, jwyObserveData);
            }
            finally
            {
                sW.Close();
            }
        }
        #endregion
        #region 属性定义
        /// <summary>
        /// 版本号
        /// </summary>
        [XmlAttribute("版本号")]
        public string VersionNumber { get; set; }
        /// <summary>
        /// 观测开始时间
        /// </summary>
        [XmlAttribute("放球时间")]
        public string StartTime { get; set; }
        /// <summary>
        /// 固定站号
        /// </summary>
        [XmlAttribute("固定站号")]
        public string FixStationId { get; set; }
        /// <summary>
        /// 设备类型XJE05
        /// </summary>
        [XmlAttribute("设备型号")]
        public string DeviceType { get; set; }
        /// <summary>
        /// 基本信息
        /// </summary>
        [XmlElement("基本信息")]
        public BaseInfoV2d0 BaseInfo { get; set; }

        /// <summary>
        /// 测站参数
        /// </summary>
        [XmlElement("测站参数")]
        public StationInfoV2d0 StationInfo { get; set; }
        /// <summary>
        /// 气球参数
        /// </summary>
        [XmlElement("气球参数")]
        public BallonInfoV2d0 BallonInfo { get; set; }
        /// <summary>
        /// 地面气象要素
        /// </summary>
        [XmlElement("地面气象要素")]
        public GroundObserveInfoV2d0 GroundObserveInfo { get; set; }
        /// <summary>
        /// 观测数据
        /// </summary>
        [XmlElement("观测数据")]
        public TargetTEADatasV2d0 TargetTEADatas { get; set; }

        /// <summary>
        /// 计算层风数据
        /// </summary>
        [XmlElement("计算层风数据")]
        public FloorWindDatasV2d0 FloorWindDatas { get; set; }
        /// <summary>
        /// 距经纬仪高度风数据
        /// </summary>
        [XmlElement("距经纬仪高度风数据")]
        public DisEquipmentWindDatasV2d0 DisEquipmentWindDatas { get; set; }
        /// <summary>
        /// 距海平面高度风数据
        /// </summary>
        [XmlElement("距海平面高度风数据")]
        public DisSeaLevelWindDatasV2d0 DisSeaLevelWindDatas { get; set; }
        /// <summary>
        /// 最大风层数据
        /// </summary>
        [XmlElement("最大风层数据")]
        public StrongWindDatasV2d0 StrongWindDatas { get; set; }

        /// <summary>
        /// 合成风数据
        /// </summary>
        [XmlElement("合成风数据")]
        public HcfDatasV2d0 HcfDatas { get; set; }

        [XmlElement("报文")]
        public BwV2d0 Bw { get; set; }

    }
    /// <summary>
    /// 基本信息
    /// </summary>
    [XmlRoot("基本信息")]
    public class BaseInfoV2d0
    {
        [XmlElement("经纬仪型号")]
        public string m_sCfyq { set; get; }//测风仪器
        [XmlElement("经纬仪编号")]
        public string m_sJwybh { set; get; }//经纬仪编号
        [XmlElement("数据处理方法")]
        public string m_sSjclff { set; get; }//数据处理方法
        [XmlElement("仰角器差")]
        public float m_fElevationDeviation { set; get; }//仰角器差
        [XmlElement("方位角器差")]
        public float m_fAzimuthDeviation { set; get; }//方位角器差
        [XmlElement("文件名")]
        public string m_sFilename { set; get; }//数据文件名
        [XmlElement("固定站号")]
        public string m_sJmzh { set; get; }//加密站号
        [XmlElement("放球日期年")]
        public int m_iFqsj_year { set; get; }//放球时间年
        [XmlElement("放球日期月")]
        public int m_iFqsj_month { set; get; }//放球时间月
        [XmlElement("放球日期日")]
        public int m_iFqsj_day { set; get; }//放球时间日
        [XmlElement("放球日期时")]
        public int m_iFqsj_hour { set; get; }//放球时间小时
        [XmlElement("放球日期分")]
        public int m_iFqsj_minute { set; get; }//放球时间分
        [XmlElement("气球升速")]
        public int m_nBallVelocity { set; get; }//气球升速
        [XmlElement("是否远距离放球")]
        public string m_sCheckDistance { set; get; }//是否远距离放球
        [XmlElement("远距离放球方位")]
        public float m_fLongDistanceDir { set; get; }//远距离放球方位
        [XmlElement("远距离放球距离")]
        public float m_fLongDistance { set; get; }//远距离放球距离
        [XmlElement("观测时长")]
        public float m_fGcsj { set; get; }//观测时长
        [XmlElement("数据个数")]
        public int m_iSjgs { set; get; }//数据个数
        [XmlElement("失视原因")]
        public static string m_sSsyy { set; get; }//失视原因
        [XmlElement("入云时间时")]
        public int m_iRysj_hour { set; get; }//入云时间，时，分，秒
        [XmlElement("入云时间分")]
        public int m_iRysj_minute { set; get; }
        [XmlElement("入云时间秒")]
        public int m_iRysj_second { set; get; }
        [XmlElement("放球终止时间时")]
        public int m_iFqzzsj_hour { set; get; }//放球终止时间，时，分，秒
        [XmlElement("放球终止时间分")]
        public int m_iFqzzsj_minute { set; get; }
        [XmlElement("放球终止时间秒")]
        public int m_iFqzzsj_second { set; get; }
        [XmlElement("是否缺测")]
        public bool m_bSfqc { set; get; }//是否缺测
        [XmlElement("备注")]
        public string m_sBz { set; get; }//备注
        [XmlElement("放球次数")]
        public static int m_iFqcs { set; get; }//放球次数
        [XmlElement("观测者")]
        public static string m_sGcz { set; get; }//观测者
        [XmlElement("计算者")]
        public static string m_sJsz { set; get; }//计算者
        [XmlElement("校对者")]
        public static string m_sJdz { set; get; }//校对者        
    }

    /// <summary>
    /// 测站参数
    /// 8
    /// </summary>
    [XmlRoot("基本信息")]
    public class StationInfoV2d0
    {
        [XmlElement("站名")]
        public string m_sZm { set; get; }//站名
        [XmlElement("固定站号")]
        public string m_sGdzh { set; get; }//固定站号
        [XmlElement("加密站号")]
        public string m_sJmzh { set; get; }//加密站号
        [XmlElement("海拔高度")]
        public float m_fAltitude { set; get; }//海拔高度

        [XmlElement("东经度")]
        public int m_iDjd { set; get; }//东经度
        [XmlElement("东经分")]
        public int m_iDjf { set; get; }//东经分
        [XmlElement("北纬度")]
        public int m_iBwd { set; get; }//北纬度
        [XmlElement("北纬分")]
        public int m_iBwf { set; get; }//北纬分
    }

    /// <summary>
    /// 气球参数
    /// 7
    /// </summary>
    [XmlRoot("基本信息")]
    public class BallonInfoV2d0
    {
        [XmlElement("气球颜色")]
        public string m_sQqys { set; get; }//气球颜色
        [XmlElement("球皮重")]
        public int m_iQpz { set; get; }//球皮重
        [XmlElement("附加物重")]
        public int m_iFjwz { set; get; }//附加物重
        [XmlElement("标准密度升速值")]
        public int m_iBzmdssz { set; get; }//标准密度升速值
        [XmlElement("净举力")]
        public int m_iJjl { set; get; }//净举力
        [XmlElement("总举力")]
        public int m_iZjl { set; get; }//总举力
        [XmlElement("砝码重")]
        public int m_iFmz { set; get; }//砝码重
    }
    /// <summary>
    /// 地面气象要素
    /// </summary>
    [XmlRoot("基本信息")]
    public class GroundObserveInfoV2d0
    {
        [XmlElement("有效能见度")]
        public int m_iYxnjd { set; get; }//有效能见度
        [XmlElement("天气现象")]
        public string m_sTstqxx { set; get; }//特殊天气现象
        [XmlElement("放球前云量")]
        public string m_sFqqyl { set; get; }//放球前 总云量/低云量
        [XmlElement("放球前云状")]
        public string m_sFqqyz { set; get; }//放球前云状
        [XmlElement("地面气温")]
        public float m_fDmqw { set; get; }//地面气温
        [XmlElement("地面气压")]
        public float m_fDmqy { set; get; }//地面气压
        [XmlElement("地面湿度")]
        public float m_fDmsd { set; get; }//地面湿度
        [XmlElement("地面风向")]
        public int m_iGroundWindDir { set; get; }//地面风向
        [XmlElement("地面风速")]
        public int m_iGroundWindVec { set; get; } //地面风速
        [XmlElement("放球前仰角")]
        public float m_fFqqyj { set; get; }//放球前仰角
        [XmlElement("放球前方位角")]
        public float m_fFqqfwj { set; get; }//放球前方位角
        [XmlElement("放球后仰角")]
        public float m_fFqhyj { set; get; }//放球后仰角
        [XmlElement("放球后方位角")]
        public float m_fFqhfwj { set; get; }//放球后方位角
        [XmlElement("仰角差值")]
        public float m_fYjcz { set; get; }//仰角差值
        [XmlElement("方位角差值")]
        public float m_fFwjcz { set; get; }//方位角差值

        [XmlElement("人工读取仰角")]
        public float m_fRgdqyj { set; get; }//放球结束后人工读取的仰角
        [XmlElement("人工读取方位角")]
        public float m_fRgdqfwj { set; get; }//放球结束后人工读取的方位角
        [XmlElement("自动采集仰角")]
        public float m_fZdcjyj { set; get; }//放球结束后自动采集的仰角
        [XmlElement("自动采集方位角")]
        public float m_fZdcjfwj { set; get; }//放球结束后自动采集的方位角
        [XmlElement("光电仰角差值")]
        public float m_fGdyjcz { set; get; }//05型光电仰角差值
        [XmlElement("光电方位角差值")]
        public float m_fGdfwjcz { set; get; }//05型光电方位角差值
        [XmlElement("放球后云量")]
        public string m_sFqhyl { set; get; }//放球后 总云量/低云量
        [XmlElement("放球后云状")]
        public string m_sFqhyz { set; get; }//放球后云状
        [XmlElement("实测云底高")]
        public int m_iZsydg { set; get; }//真实云底高

    }
    /// <summary>
    /// 观测数据 目标时间方位仰角数据集
    /// </summary>
    [XmlRoot("观测数据")]
    public class TargetTEADatasV2d0
    {
        [XmlAttribute("观测数据个数")]
        public int m_iSjgs { set; get; }
        [XmlElement("数据")]
        public List<TargetTEADataV2d0> TargetTEADatas { get; set; }
    }
    /// <summary>
    /// 目标时间方位仰角数据
    /// </summary>
    //[XmlRoot("数据")]
    [Serializable()]
    public class TargetTEADataV2d0
    {
        [XmlAttribute("序号")]
        public int m_iGroupIndex { get; set; }
        [XmlAttribute("分")]
        public int GcTime_m { get; set; }
        [XmlAttribute("秒")]
        public int GcTime_s { get; set; }
        [XmlAttribute("仰角")]
        public float GcElevation { get; set; }
        [XmlAttribute("方位角")]
        public float GcAzimuth { get; set; }
        /*
        public double InitDataTime { get; set; }
        public double InitDataA{get;set;}
        public double InitDataB{get;set;}
        public int InitDataTime_m{get;set;}
        public int InitDataTime_s { get; set; }

        public int m_iSecond { get; set; }
        public double m_dElevation { get; set; }
        public double m_dAzimuth { get; set; }
         * */
    }
    /// <summary>
    /// 计算层风数据集类
    /// </summary>
    [XmlRoot("计算层风数据")]
    public class FloorWindDatasV2d0
    {
        [XmlAttribute("计算层风个数")]
        public int m_iSjgs { get; set; }
        [XmlElement("数据")]
        public List<FloorWindDataV2d0> FloorWindDatas { get; set; }

    }
    /// <summary>
    /// 计算层风数据
    /// </summary>
    [Serializable()]
    public class FloorWindDataV2d0
    {
        [XmlAttribute("序号")]
        public int m_iGroupIndex { get; set; }
        [XmlAttribute("时间")]
        public double FloorWindTime { get; set; }
        [XmlAttribute("高度")]
        public double FloorWindDir { get; set; }
        [XmlAttribute("风向")]
        public double FloorWindVec { get; set; }
        [XmlAttribute("风速")]
        public double FloorWindTopTime { get; set; }
    }
    /// <summary>
    /// 距经纬仪规定高度风数据集类
    /// </summary>
    [XmlRoot("距经纬仪高度风数据")]
    public class DisEquipmentWindDatasV2d0
    {
        [XmlAttribute("距经纬仪高度风个数")]
        public int m_iSjgs { set; get; }
        [XmlElement("数据")]
        public List<DisEquipmentWindDataV2d0> DisEquipmentWindDatas { get; set; }
    }
    /// <summary>
    /// 距经纬仪规定高度风数据类
    /// </summary>
    [Serializable()]
    public class DisEquipmentWindDataV2d0
    {
        [XmlAttribute("序号")]
        public int m_iGroupIndex { get; set; }
        [XmlAttribute("时间")]
        public double DisEquipmentWindTime { get; set; }
        [XmlAttribute("高度")]
        public int DisEquipmentWindHeight { get; set; }
        [XmlAttribute("风向")]
        public double DisEquipmentWindDir { get; set; }
        [XmlAttribute("风速")]
        public double DisEquipmentWindVec { get; set; }
    }
    /// <summary>
    /// 距海平面规定高度风数据集类
    /// </summary>
    [XmlRoot("距海平面高度风数据")]
    public class DisSeaLevelWindDatasV2d0
    {
        [XmlAttribute("距海平面高度风个数")]
        public int m_iSjgs { set; get; }
        [XmlElement("数据")]
        public List<DisSeaLevelWindDataV2d0> DisSeaLevelWindDatas { get; set; }
    }
    /// <summary>
    /// 距海平面规定高度风数据类
    /// </summary>
    [Serializable()]
    public class DisSeaLevelWindDataV2d0
    {
        [XmlAttribute("序号")]
        public int m_iGroupIndex { get; set; }
        [XmlAttribute("时间")]
        public double DisSeaLevelWindTime { get; set; }
        [XmlAttribute("高度")]
        public int DisSeaLevelWindHeight { get; set; }
        [XmlAttribute("风向")]
        public double DisSeaLevelWindDir { get; set; }
        [XmlAttribute("风速")]
        public double DisSeaLevelWindVec { get; set; }
    }


    /// <summary>
    /// 最大风层数据集类
    /// </summary>
    [XmlRoot("最大风层数据")]
    public class StrongWindDatasV2d0
    {
        [XmlAttribute("最大风层个数")]
        public int m_iSjgs { get; set; }
        [XmlElement("数据")]
        public List<StrongWindDataV2d0> StrongWindDatas { get; set; }
    }
    /// <summary>
    /// 最大风层数据类
    /// </summary>
    [Serializable()]
    public class StrongWindDataV2d0
    {
        [XmlAttribute("序号")]
        public int m_iGroupIndex { get; set; }
        [XmlAttribute("是否闭合")]
        public bool StrongWindClose { get; set; }
        [XmlAttribute("高度")]
        public double StrongWindHeight { get; set; }
        [XmlAttribute("风向")]
        public double StrongWindDir { get; set; }
        [XmlAttribute("风速")]
        public double StrongWindVec { get; set; }
    }

    /// <summary>
    /// 合成风数据集类
    /// </summary>
    [XmlRoot("合成风数据")]
    public class HcfDatasV2d0
    {
        [XmlAttribute("合成风个数")]
        public int m_iSjgs { get; set; }
        [XmlElement("数据")]
        public List<HcfDataV2d0> HcfDatas { get; set; }
    }
    /// <summary>
    /// 合成风数据类
    /// </summary>
    [Serializable()]
    public class HcfDataV2d0
    {
        [XmlAttribute("序号")]
        public int m_iGroupIndex { get; set; }
        /// <summary>
        /// 合成风底部高度
        /// </summary>
        [XmlAttribute("底部高度")]
        public int ResultantWindHeight1 { get; set; }
        /// <summary>
        /// 合成风顶部高度
        /// </summary>
        [XmlAttribute("顶部高度")]
        public int ResultantWindHeight2 { get; set; }
        /// <summary>
        /// 合成风方向
        /// </summary>
        [XmlAttribute("风向")]
        public double ResultantWindDir { get; set; }
        /// <summary>
        /// 合成风风速
        /// </summary>
        [XmlAttribute("风速")]
        public double ResultantWindVec { get; set; }
    }
    /// <summary>
    /// 报文类
    /// </summary>
    [XmlRoot("报文")]
    public class BwV2d0
    {
        [XmlAttribute("报文类型")]
        public string m_sBwlx { get; set; }
        /// <summary>
        /// 报文的部数据集
        /// </summary>
        [XmlElement("部")]
        public List<BwBuDataV2d0> BwBuDatas { get; set; }//报文的部 识别组 A部 B部 C部 D部
    }
    /// <summary>
    /// 报文部数据
    /// </summary>
    [Serializable()]
    public class BwBuDataV2d0
    {
        [XmlAttribute("部名称")]
        public string m_sBmc { get; set; }
        [XmlAttribute("报文组数")]
        public int m_iSjgs { get; set; }
        /// <summary>
        /// 报文的组数据集
        /// </summary>
        [XmlElement("数据")]
        public List<BwZuDataV2d0> BwZuDatas { get; set; }
    }
    /// <summary>
    /// 报文组数据
    /// </summary>
    [Serializable()]
    public class BwZuDataV2d0
    {
        [XmlAttribute("序号")]
        public int m_iGroupIndex { get; set; }
        /// <summary>
        /// 报文数据
        /// </summary>
        [XmlAttribute("报文")]
        public string m_sBwCode { get; set; }
        #endregion
    }
}
