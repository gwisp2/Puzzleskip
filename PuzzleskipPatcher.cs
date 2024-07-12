using FFG.MoM;
using HarmonyLib;

namespace Puzzleskip
{
    [HarmonyPatch(typeof(PuzzleViewBase))]
    internal class PuzzleskipPatcher
    {
        [HarmonyPrefix]
        [HarmonyPatch("PuzzleClosedEvent")]
        static bool PrePuzzleClosedEvent(PuzzleViewBase __instance, ref bool completed)
        {
            SkipPuzzleButton skipPuzzleButton = __instance.gameObject.GetComponentInChildren<SkipPuzzleButton>();
            if (skipPuzzleButton.SkipEnabled)
            {
                completed = true;
            }
            return true;
        }


        [HarmonyPrefix]
        [HarmonyPatch("Show")]
        static void PreShow(PuzzleViewBase __instance)
        {
            UIButton button = FindCloseButton(__instance);
            if (button != null)
            {
                if (button.gameObject.GetComponent<SkipPuzzleButton>() == null)
                {
                    button.gameObject.AddComponent<SkipPuzzleButton>();
                }
                SkipPuzzleButton skipButton = button.gameObject.GetComponent<SkipPuzzleButton>();
                skipButton.SkipEnabled = false;
            }
        }

        private static UIButton FindCloseButton(PuzzleViewBase puzzleViewBase)
        {
            var buttons = puzzleViewBase.GetComponentsInChildren<UIButton>();
            foreach (var button in buttons)
            {
                if (button.name.Contains("Close"))
                {
                    return button;
                }
            }
            return null;
        }
    }
}
