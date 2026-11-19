# -*- coding: utf-8 -*-
import sys, re

pasted_path = r'C:/Users/Van Duc/AppData/Local/hermes/composer-pastes/pasted_content_2026-10-26_05-02-27-205_24c855.txt'
with open(pasted_path, 'r', encoding='utf-8') as f:
    orig = f.read()

# Let's verify orig has the methods we expect
assert 'public class fHDDangBai' in orig
assert 'private void InitializeComponent()' in orig
print('Read successfully.')
