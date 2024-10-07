namespace Gandalan.UI.Commands.Contracts;

public enum CommandResultStatusCode
{
    OK = 900,
    ERROR = 970,
    CANCEL = 999,
    NOT_UNDERSTOOD = 998,
    NOT_IMPLEMENTED = 980,

    InternKonfig = 100,
    ExternKonfigFile = 102,
    ExternKonfigFileTemp = 103,

    Duplizieren = 200,
    BelegPositionNichtGefunden = 990,
    VarianteNichtGefunden = 991,
    VarianteLadeFehler = 992,
    VarianteNichtErfassbar = 993,
}
