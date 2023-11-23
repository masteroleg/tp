namespace TraceavitProDesktop.services;

public enum SetLineResult : uint
{
    _Error              = 0,   // 0 => Error
    _LineNotFound       = 25,  // 25 => StationData + wrong line - TBD
    _JobDataEmergency   = 50,  // 50 => request JobData + emergency StationData??? 
    _JobDataNeedRestore = 75,  // 75 => request JobData (station is joining current job)
    _JobList            = 100, // 100 => request JobList
    Exception,
    Success,
    NoJob,
    CheckStationStatus,
    RequestJobData,
    NeedRestore
}