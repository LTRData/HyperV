namespace LTR.HyperV;

public enum VirtualMachineState : ushort
{
    Unknown = 0,
    Saving_state = 1,
    Running = 2,
    Off = 3,
    Stopping = 4,
    Saved_state = 6,
    Paused = 9,
    Starting_up = 10,
    Resetting = 11,
    Pausing = 32776,
    Resuming = 32777,
    FastSaved = 32779,
    FastSaving = 32780
}
