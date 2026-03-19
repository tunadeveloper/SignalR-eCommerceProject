// choices.js

document.addEventListener('DOMContentLoaded', function () {
  const elements = document.querySelectorAll('[data-choices]');
  elements.forEach(function (element) {
    const isInput = element.tagName.toLowerCase() === 'input';
    new Choices(element, {
      removeItemButton: element.dataset.choicesRemoveitembutton === 'true',
      itemSelectText: '',
      maxItemCount: 5,
      searchEnabled: false,
      placeholder: true,
      placeholderValue: element.getAttribute('placeholder') || 'Select an option', // Ensure placeholder is set
      classNames: {
        containerInner: isInput ? 'form-control' : 'form-select',
      },
    });
  });
});

// choices.js for innertext with badge

document.addEventListener('DOMContentLoaded', function () {
  const elements = document.querySelectorAll('[data-choices-innertext]');

  elements.forEach(function (element) {
    new Choices(element, {
      removeItemButton: element.dataset.choicesRemoveitembutton === 'true',
      itemSelectText: '',
      searchEnabled: false,
      placeholder: true,
      classNames: {
        containerInner: element.dataset.choicesClassname || 'form-select',
      },
      callbackOnCreateTemplates: function (template) {
        return {
          item: function (classNames, data) {
            const colorClass = element.querySelector(`option[value="${data.value}"]`).dataset.color;
            return template(`
             <div class="${classNames.item} ${data.highlighted ? classNames.highlightedState : classNames.itemSelectable}"
                  data-item data-id="${data.id}" data-value="${data.value}" data-deletable>
               <span class="rounded-circle ${colorClass} p-1 me-2 icon-shape " style="width:8px; height:8px"></span>
               ${data.label}
             </div>
           `);
          },
          choice: function (classNames, data) {
            const colorClass = element.querySelector(`option[value="${data.value}"]`).dataset.color;
            return template(`
             <div class="${classNames.item} ${classNames.itemChoice} ${data.disabled ? classNames.itemDisabled : classNames.itemSelectable}"
                  data-select-text="${this.config.itemSelectText}" data-choice data-id="${data.id}" data-value="${data.value}" data-choice-selectable>
               <span class="rounded-circle ${colorClass} p-1 me-2 icon-shape " style="width:8px; height:8px"></span>
               ${data.label}
             </div>
           `);
          },
        };
      },
    });
  });
});
