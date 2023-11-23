using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;

namespace TraceavitProDesktop.controls;

[GenerateViewModel]
public partial class VirtualKeyboardControl : UserControl
{
    public static readonly DependencyProperty InputStringProperty = DependencyProperty.Register(
        nameof(InputString), typeof(string), typeof(VirtualKeyboardControl), new PropertyMetadata(default(string)));

    public string InputString
    {
        get => (string)GetValue(InputStringProperty);
        set => SetValue(InputStringProperty, value);
    }


    public DelegateCommand<string> PressKeyCommand => new(value => { InputString += value; });

    [GenerateProperty] private string _Q;
    [GenerateProperty] private string _W;
    [GenerateProperty] private string _E;
    [GenerateProperty] private string _R;
    [GenerateProperty] private string _T;
    [GenerateProperty] private string _Y;
    [GenerateProperty] private string _U;
    [GenerateProperty] private string _I;
    [GenerateProperty] private string _O;
    [GenerateProperty] private string _P;
    [GenerateProperty] private string _XX;
    [GenerateProperty] private string _II;
    [GenerateProperty] private string _A;
    [GenerateProperty] private string _S;
    [GenerateProperty] private string _D;
    [GenerateProperty] private string _F;
    [GenerateProperty] private string _G;
    [GenerateProperty] private string _H;
    [GenerateProperty] private string _J;
    [GenerateProperty] private string _K;
    [GenerateProperty] private string _L;
    [GenerateProperty] private string _GG;
    [GenerateProperty] private string _EE;
    [GenerateProperty] private string _Z;
    [GenerateProperty] private string _X;
    [GenerateProperty] private string _C;
    [GenerateProperty] private string _V;
    [GenerateProperty] private string _B;
    [GenerateProperty] private string _N;
    [GenerateProperty] private string _M;
    [GenerateProperty] private string _BB;
    [GenerateProperty] private string _UU;
    private readonly List<string> links;

    public VirtualKeyboardControl()
    {
        InputString = string.Empty;
        Q = "É";
        W = "Ö";
        E = "Ó";
        R = "Ê";
        T = "Å";
        Y = "Í";
        U = "Ã";
        I = "Ø";
        O = "Ù";
        P = "Ç";
        XX = "Õ";
        II = "¯";
        A = "Ô";
        S = "²";
        D = "Â";
        F = "À";
        G = "Ï";
        H = "Ð";
        J = "Î";
        K = "Ë";
        L = "Ä";
        GG = "Æ";
        EE = "ª";
        Z = "ß";
        X = "×";
        C = "Ñ";
        V = "Ì";
        B = "È";
        N = "Ò";
        M = "Ü";
        BB = "Á";
        UU = "Þ";

         links = new List<string>()
        {
            Q, W, E, R, T, Y, U, I, O, P, XX, II,
            A, S, D, F, G, H, J, K, L, GG, EE,
            Z, X, C, V, B, N, M, BB, UU
        };

        InitializeComponent();
        DataContext = this;
    }

    private bool isShift = true;
    private DelegateCommand ShiftCommand => new DelegateCommand(() =>
    {
        isShift = !isShift;

        if (isShift) ToUpper();
            else ToLower();



    });

    private void ToUpper()
    {
        links.ForEach(x=>x = x.ToUpper());
    }
    private void ToLower()
    {
        links.ForEach(x => x = x.ToLower());
    }
}