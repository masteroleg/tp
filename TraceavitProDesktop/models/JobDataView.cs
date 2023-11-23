using System;
using DevExpress.Mvvm.CodeGenerators;

namespace TraceavitProDesktop.models;

[GenerateViewModel]
public partial class JobDataView
{
 
    [GenerateProperty] private int                    _Id;
    [GenerateProperty] private ArticleView            _ArticleRef;
    [GenerateProperty] private string                 _JobNotes    = string.Empty;
    [GenerateProperty] private string                 _JobBatchNum = string.Empty;
    [GenerateProperty] private DateTime               _JobCreatedAt;
    [GenerateProperty] private int                    _JobPlannedQty;
    [GenerateProperty] private double                 _JobPlannedVolume;
    [GenerateProperty] private DateTime               _JobPlannedStartAt;
    [GenerateProperty] private DateTime               _JobPlannedFinishAt;
    [GenerateProperty] private int                    _JobStatus;
    [GenerateProperty] private int                    _LineId;
    [GenerateProperty] private PerformanceObjectView? _JobPerformance;
    [GenerateProperty] private bool                   _IsSelected;
}

[GenerateViewModel]
public partial class ArticleView
{
    [GenerateProperty] private string  _ArticleProductCode       = string.Empty;
    [GenerateProperty] private string  _ArticleProductName       = string.Empty;
    [GenerateProperty] private string  _ArticleProductEAN        = string.Empty;
    [GenerateProperty] private int     _ArticleProductToxicNum   = 0;
    [GenerateProperty] private string  _ArticleProductToxicSpec  = string.Empty;
    [GenerateProperty] private int     _ArticleProductCodesCount = 1;
    [GenerateProperty] private byte[]    _ArticleProductImage;
    [GenerateProperty] private int     _ArticlePlanpalPaleteCount       = 1;
    [GenerateProperty] private int     _ArticlePlanpalLablerPaleteCount = 1;
    [GenerateProperty] private double  _ArticlePlanpalPaleteBrutto;
    [GenerateProperty] private double  _ArticlePlanpalPaleteNetto;
    [GenerateProperty] private int?    _ArticlePlanPalBoxCount;
    [GenerateProperty] private double? _ArticlePlanPalBoxBrutto;
    [GenerateProperty] private double? _ArticlePlanPalBoxNetto;
    [GenerateProperty] private int?    _ArticlePlanpalSmallBoxCount;
    [GenerateProperty] private double? _ArticlePlanpalSmallBoxBrutto;
    [GenerateProperty] private double? _ArticlePlanpalSmallBoxNetto;
}

[GenerateViewModel]
public partial class PerformanceObjectView
{
    [GenerateProperty] private DateTime _StartAt;
    [GenerateProperty] private DateTime _FinishedAt;
    [GenerateProperty] private int      _SmallBoxCount;
    [GenerateProperty] private int      _BoxCount;
    [GenerateProperty] private int      _PaleteCount;
    [GenerateProperty] private int      _IncompletPaleteBoxCount;
    [GenerateProperty] private int      _IncompletePaletsCount;
    [GenerateProperty] private int      _UnscannedWasteCount;
    [GenerateProperty] private int      _ScannedWasteCount;
    [GenerateProperty] private int      _PostponedCount;
}