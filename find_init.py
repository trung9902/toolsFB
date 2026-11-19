# -*- coding: utf-8 -*-
with open(r'C:/Users/Van Duc/AppData/Local/hermes/composer-pastes/pasted_content_2026-10-26_05-02-27-205_24c855.txt', 'r', encoding='utf-8') as f:
    lines = f.readlines()

# Let's inspect InitializeComponent lines
init_idx = -1
for i, line in enumerate(lines):
    if 'private void InitializeComponent()' in line:
        init_idx = i
        break

print('InitializeComponent is at line:', init_idx + 1)
