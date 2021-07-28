using CSharpVerbalExpressions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MediatR;
using System.Text.RegularExpressions;
using VeLib.Queries;

namespace VeUI
{
    public class MainWindowViewModel : ViewModelBase
    {

        private string _regEx; public string RegEx { get => _regEx; set { Set(() => RegEx, ref _regEx, value); } }
        private string _inputString; public string InputString { get => _inputString; set { Set(() => InputString, ref _inputString, value); } }
        private string _outcome; public string Outcome { get => _outcome; set { Set(() => Outcome, ref _outcome, value); } }
        private RelayCommand _processCmd;

        private readonly IMediator _mediator;

        public MainWindowViewModel()
        {

        }

        public MainWindowViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }


        public RelayCommand ProcessCmd => _processCmd ?? (_processCmd = new RelayCommand(
            () => process(),
            () => { return 1 == 1; },
            keepTargetAlive: true
            ));

        private void process()
        {
            var verExp = new VerbalExpressions()
                .StartOfLine().
                BeginCapture("lowercase")
                .Range("a", "z").EndCapture();

            Regex stdRegEx = verExp.ToRegex();
            RegEx = stdRegEx.ToString();

            Match mc =stdRegEx.Match(this.InputString);
            //var t = mc.To  stdRegEx.Matches.FirstOrDefault(["lowercase"];

            var pippo = verExp.IsMatch(InputString);
            



            Outcome = _mediator.Send(new ProcessRegExQuery(verExp, InputString)).Result;
        }
    }
}
