namespace Gandalan.IDAS.WebApi.Client.Environments;

public enum Stages
{
    Prod,
    Test,
    Dev,
    Local
}

public static class Env
{
#if STAGE_DEV
    public const Stages Stage = Stages.Dev;
#elif STAGE_TEST
    public const Stages Stage = Stages.Test;
#elif STAGE_PROD
    public const Stages Stage = Stages.Prod;
#else
    public const Stages Stage = Stages.Local;
#endif
}
