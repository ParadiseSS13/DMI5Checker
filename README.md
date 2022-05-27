# DMI5 Checker

This will fail PRs if they introduce any icons with DMI5. Remove this once tooling is stable enough to support DMI5.

## Usage

```yml
on: pull_request_target
jobs:
  check-dmi5:
    runs-on: ubuntu-latest
    name: Checks all icons to make sure there are none in DMI5
    steps:
    - uses: ParadiseSS13/DMI5Checker@v1
      with:
        icons-path: 'icons'
```

## Inputs

### `icons-path`

The path to all the icons in your codebase. Defaults to `icons`.

## Special Thanks

This action is based entirely on [https://github.com/tgstation/tgs-dmapi-updater](https://github.com/tgstation/tgs-dmapi-updater)
