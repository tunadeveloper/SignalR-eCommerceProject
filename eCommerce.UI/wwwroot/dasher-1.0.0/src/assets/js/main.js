'use strict';
var theme = {
  init: function () {
    theme.otpVarification();
    theme.checkbox();
    theme.alertJS();
    theme.popovers();
    theme.tooltip();
    theme.validation();
    theme.toast();
    theme.sidbarNav();
    theme.search();
  },

  // search
  search: () => {
    document.addEventListener('DOMContentLoaded', () => {
      const searchWord = () => {
        const input = document.getElementById('globalSearchInput').value.toLowerCase(); // Get search input
        const listItems = document.querySelectorAll('.modal-body li'); // Select all list items inside the modal body

        listItems.forEach((item) => {
          const text = item.textContent.toLowerCase(); // Get the text content of each list item
          item.style.display = text.includes(input) ? '' : 'none'; // Show/hide based on match
        });
      };

      const searchInput = document.getElementById('globalSearchInput');
      if (searchInput) {
        searchInput.addEventListener('keyup', searchWord);
      }
    });
  },

  sidbarNav: () => {
    const links = document.querySelectorAll('.sidebar-nav-fixed a');

    if (links.length) {
      links.forEach((link) => {
        link.addEventListener('click', function (event) {
          const currentPath = location.pathname.replace(/^\//, '');
          const linkPath = this.pathname.replace(/^\//, '');
          const currentHost = location.hostname;

          // Check if the link is an on-page link
          if (currentPath === linkPath && currentHost === this.hostname) {
            let target = document.querySelector(this.hash);

            if (!target) {
              target = document.querySelector(`[name="${this.hash.slice(1)}"]`);
            }

            if (target) {
              event.preventDefault();

              window.scrollTo({
                top: target.offsetTop - 90,
                behavior: 'smooth',
              });

              // Set focus after scrolling
              target.setAttribute('tabindex', '-1'); // Add tabindex for non-focusable elements
              target.focus({ preventScroll: true }); // Focus the target without scrolling again
            }
          }

          // Remove 'active' class from all links and add it to the clicked link
          links.forEach((link) => link.classList.remove('active'));
          this.classList.add('active');
        });
      });
    }
  },

  // Alert
  alertJS: () => {
    const alertPlaceholder = document.getElementById('liveAlertPlaceholder');
    const appendAlert = (message, type) => {
      const wrapper = document.createElement('div');
      wrapper.innerHTML = [
        `<div class="alert alert-${type} alert-dismissible" role="alert">`,
        `   <div>${message}</div>`,
        '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>',
        '</div>',
      ].join('');

      alertPlaceholder.append(wrapper);
    };

    const alertTrigger = document.getElementById('liveAlertBtn');
    if (alertTrigger) {
      alertTrigger.addEventListener('click', () => {
        appendAlert('Nice, you triggered this alert message!', 'success');
      });
    }
  },

  // Popovers
  popovers: () => {
    const popoverTriggerList = document.querySelectorAll('[data-bs-toggle="popover"]');
    const popoverList = [...popoverTriggerList].map((popoverTriggerEl) => new bootstrap.Popover(popoverTriggerEl));
  },

  // Tooltip
  tooltip: () => {
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
    const tooltipList = [...tooltipTriggerList].map((tooltipTriggerEl) => new bootstrap.Tooltip(tooltipTriggerEl));
  },

  // Validation
  validation: () => {
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    const forms = document.querySelectorAll('.needs-validation');
    // Loop over them and prevent submission
    Array.from(forms).forEach((form) => {
      form.addEventListener(
        'submit',
        (event) => {
          if (!form.checkValidity()) {
            event.preventDefault();
            event.stopPropagation();
          }

          form.classList.add('was-validated');
        },
        false
      );
    });
  },

  // Toast
  toast: () => {
    const toastTrigger = document.getElementById('liveToastBtn');
    const toastLiveExample = document.getElementById('liveToast');

    if (toastTrigger) {
      const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample);
      toastTrigger.addEventListener('click', () => {
        toastBootstrap.show();
      });
    }
  },

  // Otp code
  otpVarification: () => {
    document.moveToNextInput = function (input) {
      if (input.value.length === input.maxLength) {
        // Get the index of the current input field
        const currentIndex = Array.from(input.parentElement.children).indexOf(input);

        // Get the next input field if it exists
        const nextInput = input.parentElement.children[currentIndex + 1];

        // Move focus to the next input field
        if (nextInput) {
          nextInput.focus();
        }
      }
    };
  },

  // Otp code
  checkbox: () => {
    // Select all checkboxes with a specific selector
    const checkboxes = document.querySelectorAll('[data-indeterminate="true"]');

    // Loop through the selected checkboxes and set their indeterminate state
    checkboxes.forEach((checkbox) => {
      checkbox.indeterminate = true;
    });
  },
};

theme.init();
