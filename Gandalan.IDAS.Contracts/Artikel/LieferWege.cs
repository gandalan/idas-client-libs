namespace Gandalan.IDAS.Contracts;

public abstract class LieferWegBase
{
    public decimal LieferKosten { get; set; }
    public bool LieferKostenKumulierbar { get; set; }
}

public abstract class SpeditionsLieferung : LieferWegBase
{
}

public abstract class PaketdienstLieferung : LieferWegBase
{
}

public abstract class BriefLieferung : LieferWegBase
{
}

public abstract class DigitaleLieferung : LieferWegBase
{
}