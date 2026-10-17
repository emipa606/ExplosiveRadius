# GitHub Copilot Instructions for Explosive Radius (Continued)

## Mod Overview and Purpose

**Mod Name:** Explosive Radius (Continued)  
**Author:** colinfang  
**Display Name:** Explosive Radius (Continued)  
**PackageId:** Mlie.ExplosiveRadius  

The Explosive Radius mod is a quality of life (QoL) mod for RimWorld that visually displays the explosion radius of all explosives upon selection and placement. This feature is designed to help players manage and strategize the placement of explosive devices more effectively. While the mod is compatible with most other mods, there is currently an incompatibility issue with the Combat Extended mod. Feedback is encouraged and can be provided through comments or by reaching out on the dedicated Discord channel.

## Key Features and Systems

- **Display Explosion Radius:** Adds a visual overlay that shows the explosive radius when an explosive device is selected or being placed.
- **Broad Compatibility:** Designed to integrate with most existing mods, although it may have issues with Combat Extended.
- **Quality of Life Enhancement:** Improves game management by providing crucial information at a glance.

## Coding Patterns and Conventions

The mod development follows these coding patterns and conventions:

- **C# Files Structure:**
  - `InitUtility.cs`: Contains initialization utilities and logging for patched explosives.
  - `ThingComp_PostDrawExtraSelectionOverlays.cs`: Handles the post-drawing of additional selection overlays using a Harmony postfix.
- **Coding Conventions**: Standard C# conventions are applied, ensuring readability and maintainability, with descriptive naming for types and members.

## XML Integration

- **about.xml**: Contains meta-information about the mod, such as dependencies and versioning.
- **Dependencies**: The mod relies on the `brrainz.harmony` library for patching and integration.

## Harmony Patching

This mod utilizes Harmony for runtime patching:

- **Postfix Method**: A postfix is used within `ThingComp_PostDrawExtraSelectionOverlays.cs` to modify the behavior of the base game methods, enabling custom drawing of the explosive radius overlay.

## Suggestions for Copilot

When using GitHub Copilot to assist with this mod, consider the following suggestions to maximize efficiency:

1. **Code Completion**: Use Copilot to suggest boilerplate code for new C# classes or methods to maintain consistent coding conventions.
2. **Error Debugging**: Leverage Copilot’s code suggestions when dealing with runtime errors or mod compatibility issues.
3. **XML Integration**: Utilize Copilot for XML formatting and ensuring dependencies are correctly stated.
4. **Harmony Patch Suggestions**: Let Copilot propose Harmony patching techniques, especially when introducing new modifications or interfacing existing features with new patches.
5. **Enhanced Logging**: Consider Copilot’s suggestions for expanding logging capabilities within the `LogPatchedExplosives` to better track patched elements.

By following this guide, developers working on the Explosive Radius (Continued) mod can effectively utilize GitHub Copilot to enhance productivity and maintain consistent development practices.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

