using System.Collections.Generic;

namespace Config{
public class Configs : BaseConfigReader{
    
    private Dictionary<int,DataFruitMachine> _DataFruitMachine;
    public Dictionary<int, DataFruitMachine> DataFruitMachine{
        get{
        if (_DataFruitMachine == null){
            _DataFruitMachine = LoadConfig<DataFruitMachine>();
        }
        return _DataFruitMachine;
        }
    }
    private Dictionary<int,DataGrading> _DataGrading;
    public Dictionary<int, DataGrading> DataGrading{
        get{
        if (_DataGrading == null){
            _DataGrading = LoadConfig<DataGrading>();
        }
        return _DataGrading;
        }
    }
    private Dictionary<int,DataShortCut> _DataShortCut;
    public Dictionary<int, DataShortCut> DataShortCut{
        get{
        if (_DataShortCut == null){
            _DataShortCut = LoadConfig<DataShortCut>();
        }
        return _DataShortCut;
        }
    }
    private Dictionary<int,DataShortCut2> _DataShortCut2;
    public Dictionary<int, DataShortCut2> DataShortCut2{
        get{
        if (_DataShortCut2 == null){
            _DataShortCut2 = LoadConfig<DataShortCut2>();
        }
        return _DataShortCut2;
        }
    }
    private Dictionary<int,DataShortCut3> _DataShortCut3;
    public Dictionary<int, DataShortCut3> DataShortCut3{
        get{
        if (_DataShortCut3 == null){
            _DataShortCut3 = LoadConfig<DataShortCut3>();
        }
        return _DataShortCut3;
        }
    }
    private Dictionary<int,DataVip> _DataVip;
    public Dictionary<int, DataVip> DataVip{
        get{
        if (_DataVip == null){
            _DataVip = LoadConfig<DataVip>();
        }
        return _DataVip;
        }
    }
    private Dictionary<int,DataSign> _DataSign;
    public Dictionary<int, DataSign> DataSign{
        get{
        if (_DataSign == null){
            _DataSign = LoadConfig<DataSign>();
        }
        return _DataSign;
        }
    }
    private Dictionary<int,DataVipSign> _DataVipSign;
    public Dictionary<int, DataVipSign> DataVipSign{
        get{
        if (_DataVipSign == null){
            _DataVipSign = LoadConfig<DataVipSign>();
        }
        return _DataVipSign;
        }
    }
    private Dictionary<int,DataChouJiang> _DataChouJiang;
    public Dictionary<int, DataChouJiang> DataChouJiang{
        get{
        if (_DataChouJiang == null){
            _DataChouJiang = LoadConfig<DataChouJiang>();
        }
        return _DataChouJiang;
        }
    }
    private Dictionary<int,DataOnLineReward> _DataOnLineReward;
    public Dictionary<int, DataOnLineReward> DataOnLineReward{
        get{
        if (_DataOnLineReward == null){
            _DataOnLineReward = LoadConfig<DataOnLineReward>();
        }
        return _DataOnLineReward;
        }
    }
    private Dictionary<int,DataTask> _DataTask;
    public Dictionary<int, DataTask> DataTask{
        get{
        if (_DataTask == null){
            _DataTask = LoadConfig<DataTask>();
        }
        return _DataTask;
        }
    }
}
}